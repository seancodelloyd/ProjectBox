using Autoboxd.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Autoboxd.Items
{
    public class ItemRepository :
        EfCoreRepository<AutoboxdDbContext, Item, Guid>,
        IItemRepository
    {
        public ItemRepository(IDbContextProvider<AutoboxdDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Item> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(item => item.Name == name);
        }
    }
}
