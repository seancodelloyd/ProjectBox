using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

using Autoboxd.ListItems;

namespace Autoboxd.Lists
{
    public class ListAppService : CrudAppService<
            List,
            ListDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateListDto>,
            IListAppService
    {
        public ListAppService(IRepository<List, Guid> repository) : base(repository)
        {
        }

        public async Task<ListDto> AddItem(Guid listId, Guid itemId)
        {
            var list = await Repository.SingleOrDefaultAsync(l => l.Id == listId);

            if (list.ListItems == null)
                list.ListItems = new List<ListItem>();

            list.ListItems.Add(new ListItem
            {
                ListId = listId,
                ItemId = itemId
            });

            await CurrentUnitOfWork.SaveChangesAsync();

            var listDto = ObjectMapper.Map<List, ListDto>(list);

            return listDto;
        }
    }
}
