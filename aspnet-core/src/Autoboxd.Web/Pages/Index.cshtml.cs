using Autoboxd.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoboxd.Web.Pages
{
    public class IndexModel : AutoboxdPageModel
    {
        public readonly IItemAppService _itemAppService;

        public IEnumerable<ItemDto> FeaturedItems { get; set; }

        public IndexModel(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        public void OnGet()
        {
            Task<IEnumerable<ItemDto>> task = Task.Run(() => _itemAppService.GetFeatured(4));

            FeaturedItems = task.Result;
        }
    }
}