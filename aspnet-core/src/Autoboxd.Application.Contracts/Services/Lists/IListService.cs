using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Autoboxd.Lists
{
    public interface IListService : ICrudAppService<
        ListDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateListDto>
    {
    }
}
