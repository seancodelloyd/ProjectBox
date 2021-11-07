using Autoboxd.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Autoboxd.Reviews
{
    public class ReviewRepository :
        EfCoreRepository<AutoboxdDbContext, Review, Guid>,
        IReviewRepository
    {
        public ReviewRepository(IDbContextProvider<AutoboxdDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }


        public override async Task<IQueryable<Review>> WithDetailsAsync()
        {
            var dbSet = await GetDbSetAsync();

            return dbSet
                .Include(x => x.Item);
        }
    }
}
