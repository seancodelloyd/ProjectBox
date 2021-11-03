using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

using Autoboxd.ListItems;

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
        public ListAppService(IListRepository repository) : base(repository)
        {
        }

        public override async Task<PagedResultDto<ListDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.WithDetailsAsync();

            var query = from list in queryable
                        select new { list };

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var listDtos = queryResult.Select(x =>
            {
                var listDto = ObjectMapper.Map<List, ListDto>(x.list);
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
