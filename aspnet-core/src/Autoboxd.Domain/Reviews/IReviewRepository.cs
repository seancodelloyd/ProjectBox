using System;
using Volo.Abp.Domain.Repositories;

namespace Autoboxd.Reviews
{
    public interface IReviewRepository : IRepository<Review, Guid>
    {
    }
}
