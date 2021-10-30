using Autoboxd.Items;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Autoboxd.Services.Items
{
    public interface IItemService : ICrudAppService<
        ItemDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateItemDto>
    {
    }
}
