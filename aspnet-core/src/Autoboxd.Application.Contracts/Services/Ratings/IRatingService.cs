using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Autoboxd.Ratings
{
    public interface IRatingService : ICrudAppService<
        RatingDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateRatingDto>
    {
    }
}
