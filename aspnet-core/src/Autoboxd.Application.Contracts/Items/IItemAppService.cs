﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Autoboxd.Items
{
    public interface IItemAppService : ICrudAppService<
        ItemDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateItemDto>
    {
        public Task<ItemDto> GetByPathAsync(string path);
        public Task<IEnumerable<ItemDto>> GetFeatured(int count);
        public Task<IEnumerable<ItemDto>> GetRecentlyReviewed(int count);
        public Task<IEnumerable<string>> GetBrands();
        public Task<PagedResultDto<ItemDto>> GetFilteredListAsync(PagedAndSortedResultRequestDto reviewInput, ItemSearchFilter filter);
    }
}
