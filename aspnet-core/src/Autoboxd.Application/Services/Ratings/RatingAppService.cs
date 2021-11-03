using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Autoboxd.Ratings
{
    public class RatingAppService : CrudAppService<
            Rating,
            RatingDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateRatingDto>,
            IListAppService
    {
        public RatingAppService(IRepository<Rating, Guid> repository) : base(repository)
        {

        }
    }
}
