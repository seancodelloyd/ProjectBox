using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Autoboxd.Lists
{
    public interface IListRepository : IRepository<List, Guid>
    {
    }
}
