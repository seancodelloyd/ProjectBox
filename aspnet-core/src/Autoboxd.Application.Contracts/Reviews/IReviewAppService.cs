using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Autoboxd.Reviews
{
    public interface IReviewAppService : ICrudAppService<
        ReviewDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateReviewDto>
    {
    }
}
