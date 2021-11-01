using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Autoboxd.Items
{
    public interface IItemService : ICrudAppService<
        ItemDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateListDto>
    {
        public Task<ItemDto> GetByPathAsync(string path);
        public Task<IEnumerable<ItemDto>> GetFeatured(int count);
    }
}
