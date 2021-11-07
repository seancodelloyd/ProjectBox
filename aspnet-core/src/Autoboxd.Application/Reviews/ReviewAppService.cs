using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

using System.Collections.Generic;
using System.Linq.Dynamic.Core;


namespace Autoboxd.Reviews
{
    public class ReviewAppService : CrudAppService<
            Review,
            ReviewDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateReviewDto>,
            IReviewAppService
    {
        public ReviewAppService(IReviewRepository repository) : base(repository)
        {
        }

        public override async Task<ReviewDto> GetAsync(Guid id)
        {
            var queryable = await Repository.WithDetailsAsync();

            var query = from review in queryable
                        where review.Id == id
                        select new { review };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Review), id);
            }

            var reviewDto = ObjectMapper.Map<Review, ReviewDto>(queryResult.review);
            return reviewDto;
        }

        public override async Task<PagedResultDto<ReviewDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.WithDetailsAsync();

            var query = from review in queryable
                        select new { review };

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var reviewDtos = queryResult.Select(x =>
            {
                var reviewDto = ObjectMapper.Map<Review, ReviewDto>(x.review);
                return reviewDto;
            }).ToList();

            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<ReviewDto>(
                totalCount,
                reviewDtos
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"review.{nameof(Review.Title)}";
            }

            return $"review.{sorting}";
        }
    }
}
