using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

using Autoboxd.ListItems;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Entities;

namespace Autoboxd.Lists
{
    public class ListAppService : CrudAppService<
            List,
            ListDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateListDto>,
            IListAppService
    {
        private readonly IRepository<IdentityUser, Guid> _identityUserRepository;

        public ListAppService(IListRepository repository, IRepository<IdentityUser, Guid> identityUserRepository) : base(repository)
        {
            _identityUserRepository = identityUserRepository;
        }

        public override async Task<ListDto> GetAsync(Guid id)
        {
            var queryable = await Repository.WithDetailsAsync();

            var query = from list in queryable
                        join creator in _identityUserRepository on list.CreatorId equals creator.Id
                        where list.Id == id
                        select new { list, creator };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(List), id);
            }

            var listDto = ObjectMapper.Map<List, ListDto>(queryResult.list);
            var creatorDto = ObjectMapper.Map<IdentityUser, IdentityUserDto>(queryResult.creator);

            listDto.Creator = creatorDto;

            return listDto;
        }

        public override async Task<PagedResultDto<ListDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.WithDetailsAsync();

            var query = from list in queryable
                        join user in _identityUserRepository on list.CreatorId equals user.Id
                        select new { list, user };

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var listDtos = queryResult.Select(x =>
            {
                var listDto = ObjectMapper.Map<List, ListDto>(x.list);
                var userDto = ObjectMapper.Map<IdentityUser, IdentityUserDto>(x.user);

                listDto.Creator = userDto;

                return listDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ListDto>(
                totalCount,
                listDtos
            );
        }

        public async Task<ListDto> AddItem(Guid listId, Guid itemId)
        {
            var list = await Repository.SingleOrDefaultAsync(l => l.Id == listId);

            if (list.ListItems == null)
                list.ListItems = new List<ListItem>();

            list.ListItems.Add(new ListItem
            {
                ListId = listId,
                ItemId = itemId
            });

            await CurrentUnitOfWork.SaveChangesAsync();

            var listDto = ObjectMapper.Map<List, ListDto>(list);

            return listDto;
        }

        // TODO: Get Lists for user
        // TODO: Get Lists for item (sort by popularity)
        // TODO: Get popular lists
        // TODO: Get recently created lists

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"list.{nameof(List.Title)}";
            }

            return $"list.{sorting}";
        }
    }
}
