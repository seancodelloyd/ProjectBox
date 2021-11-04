using Autoboxd.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoboxd.Web.Pages
{
    public class IndexModel : AutoboxdPageModel
    {
        public readonly IItemAppService _itemAppService;

        public IEnumerable<ItemDto> FeaturedItems { get; set; }
        public IEnumerable<ItemDto> RecentlyReviewed { get; set; }

        public IndexModel(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        public async Task OnGetAsync()
        {
            FeaturedItems = await _itemAppService.GetFeatured(4);
            RecentlyReviewed = await _itemAppService.GetRecentlyReviewed(12);
        }
    }
}