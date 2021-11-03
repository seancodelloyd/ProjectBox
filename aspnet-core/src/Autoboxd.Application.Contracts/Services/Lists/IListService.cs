using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Autoboxd.Lists
{
    public interface IListAppService : ICrudAppService<
        ListDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateListDto>
    {
        public Task<ListDto> AddItem(Guid listId, Guid itemId);
    }
}
