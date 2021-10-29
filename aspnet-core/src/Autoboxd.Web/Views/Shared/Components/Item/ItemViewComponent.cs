using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoboxd.Web.Components.Item
{
    [ViewComponent(Name = "Item")]
    public class ItemViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<string> categories = new List<string>() {
                "Category 1", "Category 2", "Category 3", "Category 4", "Category 5"
            };

            return View("Index", categories);
        }

    }
}