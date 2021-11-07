using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

using Autoboxd.Items;
using Autoboxd.Reviews;
using Autoboxd.Lists;

namespace Autoboxd.Web.Pages
{
    public class IndexModel : AutoboxdPageModel
    {
        public readonly IItemAppService _itemAppService;
        public readonly IReviewAppService _reviewAppService;
        public readonly IListAppService _listAppService;

        public IEnumerable<ItemDto> FeaturedItems { get; set; }
        public IEnumerable<ItemDto> RecentlyReviewed { get; set; }
        public IEnumerable<ReviewDto> PopularReviews { get; set; }
        public IEnumerable<ListDto> PopularLists { get; set; }

        public IndexModel(IItemAppService itemAppService, IReviewAppService reviewAppService, IListAppService listAppService)
        {
            _itemAppService = itemAppService;
            _reviewAppService = reviewAppService;
            _listAppService = listAppService;
        }

        public async Task OnGetAsync()
        {
            FeaturedItems = await _itemAppService.GetFeatured(4);
            RecentlyReviewed = await _itemAppService.GetRecentlyReviewed(12);

            var popularReviewInput = new PagedAndSortedResultRequestDto()
            {
                Sorting = "Title", // TODO: Change to rating later
                MaxResultCount = 10
            };

            var popularReviews = await _reviewAppService.GetListAsync(popularReviewInput);
            PopularReviews = popularReviews.Items;

            var popularListInput = new PagedAndSortedResultRequestDto()
            {
                Sorting = "Title", // TODO: Change to number of favourites later
                MaxResultCount = 10
            };

            var popularLists = await _listAppService.GetListAsync(popularListInput);
            PopularLists = popularLists.Items;
        }
    }
}