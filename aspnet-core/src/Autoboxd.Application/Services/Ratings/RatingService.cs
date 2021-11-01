﻿using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Autoboxd.Ratings
{
    public class RatingService : CrudAppService<
            Rating,
            RatingDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateRatingDto>,
            IListService
    {
        public RatingService(IRepository<Rating, Guid> repository) : base(repository)
        {

        }
    }
}
