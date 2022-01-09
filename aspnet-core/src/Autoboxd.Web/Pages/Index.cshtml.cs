using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Volo.Abp.Application.Dtos;

using Autoboxd.Items;
using Autoboxd.Reviews;
using Autoboxd.Lists;
using Autoboxd.Comments;

namespace Autoboxd.Web.Pages
{
    public class IndexModel : AutoboxdPageModel
    {
        public readonly IItemAppService _itemAppService;
        public readonly IReviewAppService _reviewAppService;
        public readonly IListAppService _listAppService;
        public readonly ICommentAppService _commentAppService;

        public IEnumerable<ItemDto> FeaturedItems { get; set; }
        public IEnumerable<ItemDto> RecentlyReviewed { get; set; }
        public IEnumerable<ReviewDto> PopularReviews { get; set; }
        public IEnumerable<ListDto> PopularLists { get; set; }

        public IEnumerable<CommentDto> Comments { get; set; }

        public IndexModel(IItemAppService itemAppService, 
            IReviewAppService reviewAppService, 
            IListAppService listAppService,
            ICommentAppService commentAppService)
        {
            _itemAppService = itemAppService;
            _reviewAppService = reviewAppService;
            _listAppService = listAppService;
            _commentAppService = commentAppService;
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

            var latestCommentInput = new PagedAndSortedResultRequestDto()
            {
                Sorting = "CreationTime",
                MaxResultCount = 10
            };

            var comments = await _commentAppService.GetAll(latestCommentInput);

            Comments = comments.Items
                .Where(c => c.Creator != null)
                .OrderByDescending(c => c.CreationTime)
                .ToList();
        }
    }
}