using Autoboxd.Items;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Autoboxd.Web.Pages.Cars.List
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
