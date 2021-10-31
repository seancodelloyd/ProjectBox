using Autoboxd.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoboxd.Web.Pages
{
    public class IndexModel : AutoboxdPageModel
    {
        public readonly IItemService _itemService;

        public IEnumerable<ItemDto> FeaturedItems { get; set; }

        public IndexModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void OnGet()
        {
            Task<IEnumerable<ItemDto>> task = Task.Run(() => _itemService.GetFeatured(4));

            FeaturedItems = task.Result;
        }
    }
}