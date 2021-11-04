using Autoboxd.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Autoboxd.Lists
{
    public class ListRepository :
        EfCoreRepository<AutoboxdDbContext, List, Guid>,
        IListRepository
    {
        public ListRepository(IDbContextProvider<AutoboxdDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }


        public override async Task<IQueryable<List>> WithDetailsAsync()
        {
            var dbSet = await GetDbSetAsync();

            return dbSet.Include(x => x.ListItems).ThenInclude(li => li.Item);
        }
    }
}
