using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

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
        public ItemService(IRepository<Item, Guid> repository) : base(repository)
        {

        }
    }
}
