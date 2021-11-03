using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Autoboxd.ListItems
{
    public class ListItemAppService : CrudAppService<
            ListItem,
            ListItemDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateListItemDto>,
            IListItemAppService
    {
        public ListItemAppService(IRepository<ListItem, Guid> repository) : base(repository)
        {
        }
    }
}
