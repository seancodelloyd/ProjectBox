using Autoboxd.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

using Autoboxd.Reviews;
using Volo.Abp.Application.Dtos;

namespace Autoboxd.Web.Pages
{
    public class IndexModel : AutoboxdPageModel
    {
        public readonly IItemAppService _itemAppService;
        public readonly IReviewAppService _reviewAppService;

        public IEnumerable<ItemDto> FeaturedItems { get; set; }
        public IEnumerable<ItemDto> RecentlyReviewed { get; set; }
        public IEnumerable<ReviewDto> PopularReviews { get; set; }

        public IndexModel(IItemAppService itemAppService, IReviewAppService reviewAppService)
        {
            _itemAppService = itemAppService;
            _reviewAppService = reviewAppService;
        }

        public async Task OnGetAsync()
        {
            FeaturedItems = await _itemAppService.GetFeatured(4);
            RecentlyReviewed = await _itemAppService.GetRecentlyReviewed(12);

            var reviewInput = new PagedAndSortedResultRequestDto()
            {
                Sorting = "Title", // TODO: Change to rating later
                MaxResultCount = 10
            };

            var popularReviews = await _reviewAppService.GetListAsync(reviewInput);
            PopularReviews = popularReviews.Items;
        }
    }
}