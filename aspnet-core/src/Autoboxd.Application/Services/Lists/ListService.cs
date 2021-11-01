using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Autoboxd.Lists
{
    public class ListService : CrudAppService<
            List,
            ListDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateListDto>,
            IListService
    {
        public ListService(IRepository<List, Guid> repository) : base(repository)
        {

        }
    }
}
