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
using Autoboxd.Permissions;

namespace Autoboxd.Items
{
    public class ItemAppService : CrudAppService<
            Item,
            ItemDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateItemDto>,
            IItemAppService
    {
        private readonly IRepository<Rating, Guid> _ratingRepository;

        public ItemAppService(
            IItemRepository itemRepository,
            IRepository<Rating, Guid> ratingRepository) : base(itemRepository)
        {
            _ratingRepository = ratingRepository;

            GetPolicyName = AutoboxdPermissions.Items.Default;
            GetListPolicyName = AutoboxdPermissions.Items.Default;
            CreatePolicyName = AutoboxdPermissions.Items.Create;
            UpdatePolicyName = AutoboxdPermissions.Items.Edit;
            DeletePolicyName = AutoboxdPermissions.Items.Delete;
        }
        
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

            var itemDto = ObjectMapper.Map<Item, ItemDto>(queryResult.item);
            return itemDto;
        }

        public override async Task<PagedResultDto<ItemDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from item in queryable
                        select new { item };

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

            var itemIds = itemDtos.Select(i => i.Id).ToList();

            var ratings = _ratingRepository
                .Where(r => itemIds.Any(i => i == r.ItemId))
                .ToList();

            foreach(var item in itemDtos)
            {
                var ratingCount = ratings.Count(r => r.ItemId == item.Id);
               
                var rating = ratingCount > 0 
                    ? ratings.Where(r => r.ItemId == item.Id).Sum(r => r.Value) / ratingCount
                    : 0;

                item.Rating = rating / 2.0m;
            }

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ItemDto>(
                totalCount,
                itemDtos
            );
        }

        public async Task<ItemDto> GetByPathAsync(string path)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from item in queryable
                        where item.Path == path
                        select new { item };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Item), path);
            }

            var itemDto = ObjectMapper.Map<Item, ItemDto>(queryResult.item);

            var ratings = _ratingRepository
                .Where(r => itemDto.Id == r.ItemId)
                .ToList();

            var ratingCount = ratings.Count(r => r.ItemId == itemDto.Id);

            var rating = ratingCount > 0
                ? ratings.Where(r => r.ItemId == itemDto.Id).Sum(r => r.Value) / ratingCount
                : 0;

            itemDto.Rating = rating / 2.0m;

            return itemDto;
        }

        public async Task<IEnumerable<ItemDto>> GetFeatured(int count)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from item in queryable
                        where item.IsFeatured
                        select new { item };

            query = query
                .Skip(0)
                .Take(count);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var itemDtos = queryResult.Select(x =>
            {
                var itemDto = ObjectMapper.Map<Item, ItemDto>(x.item);
                return itemDto;
            }).ToList();

            return itemDtos;
        }

        public async Task<IEnumerable<ItemDto>> GetRecentlyReviewed(int count)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from item in queryable
                        select new { item };

            query = query
                .Skip(0)
                .Take(count);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var itemDtos = queryResult.Select(x =>
            {
                var itemDto = ObjectMapper.Map<Item, ItemDto>(x.item);
                return itemDto;
            }).ToList();

            return itemDtos;
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"item.{nameof(Item.Name)}";
            }

            return $"item.{sorting}";
        }
    }
}
