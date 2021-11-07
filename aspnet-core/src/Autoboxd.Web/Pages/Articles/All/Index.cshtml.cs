using Autoboxd.Items;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Autoboxd.Web.Pages.Articles.All
{
    public class IndexModel : PageModel
    {
        public readonly IItemAppService _itemAppService;

        public IndexModel(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        public void OnGet()
        {
        }
    }
}
