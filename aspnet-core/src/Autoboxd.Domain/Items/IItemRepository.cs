using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Autoboxd.Items
{
    public interface IItemRepository : IRepository<Item, Guid>
    {
        Task<Item> FindByNameAsync(string name);
    }
}
