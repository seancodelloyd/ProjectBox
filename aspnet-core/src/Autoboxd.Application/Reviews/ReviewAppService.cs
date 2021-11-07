using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using Volo.Abp.Identity;
using Volo.Abp.Domain.Repositories;

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
        private readonly IRepository<IdentityUser, Guid> _identityUserRepository;

        public ReviewAppService(IReviewRepository repository, IRepository<IdentityUser, Guid> identityUserRepository) : base(repository)
        {
            _identityUserRepository = identityUserRepository;
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
                        join user in _identityUserRepository on review.CreatorId equals user.Id
                        select new { review, user };

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var reviewDtos = queryResult.Select(x =>
            {
                var reviewDto = ObjectMapper.Map<Review, ReviewDto>(x.review);
                var userDto = ObjectMapper.Map<IdentityUser, IdentityUserDto>(x.user);

                reviewDto.Creator = userDto;

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
