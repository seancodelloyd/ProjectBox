using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;

using Autoboxd.Ratings;

namespace Autoboxd.Items
{
    public class ItemService : CrudAppService<
            Item,
            ItemDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateItemDto>,
            IItemService
    {
        //private readonly IRepository<Rating, Guid> _ratingRepository;

        public ItemService(
            IRepository<Item, Guid> itemRepository/*,
            IRepository<Rating, Guid> ratingRepository*/) : base(itemRepository)
        {
            //_ratingRepository = ratingRepository;
        }
        /*
        public override async Task<ItemDto> GetAsync(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from item in queryable
                        join rating in _ratingRepository on item.Id equals rating.ItemId
                        where item.Id == id
                        select new { item, rating };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Item), id);
            }

            var bookDto = ObjectMapper.Map<Item, ItemDto>(queryResult.item);
            return bookDto;
        }

        public override async Task<PagedResultDto<ItemDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from item in queryable
                        join rating in _ratingRepository on item.Id equals rating.ItemId
                        select new { item, rating };

            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var itemDtos = queryResult.Select(x =>
            {
                var itemDto = ObjectMapper.Map<Item, ItemDto>(x.item);
                return itemDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ItemDto>(
                totalCount,
                itemDtos
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"item.{nameof(Item.Name)}";
            }

            return $"item.{sorting}";
        }*/
    }
}
