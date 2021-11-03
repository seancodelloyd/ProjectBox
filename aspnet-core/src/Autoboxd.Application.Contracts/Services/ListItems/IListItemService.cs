using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Autoboxd.ListItems
{
    public interface IListItemAppService : ICrudAppService<
        ListItemDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateListItemDto>
    {
    }
}
