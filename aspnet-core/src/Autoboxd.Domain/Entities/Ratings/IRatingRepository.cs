using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Autoboxd.Ratings
{
    public interface IRatingRepository : IRepository<Rating, Guid>
    {
        Task<Rating> FindByNameAsync(string name);

        Task<List<Rating>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
