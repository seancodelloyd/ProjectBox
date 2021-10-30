using Autoboxd.Items;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Autoboxd.Services.Items
{
    public class ItemService : CrudAppService<
            Item, //The Book entity
            ItemDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateItemDto>, //Used to create/update a book
            IItemService
    {
        public ItemService(IRepository<Item, Guid> repository) : base(repository)
        {

        }
    }
}
