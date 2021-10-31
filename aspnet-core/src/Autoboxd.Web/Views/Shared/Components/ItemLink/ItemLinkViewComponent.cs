using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autoboxd.Web.Components.ItemLink
{
    [ViewComponent(Name = "ItemLink")]
    public class ItemLinkViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string imageUrl)
        {
            var model = new ItemLinkViewModel()
            {
                ImageUrl = imageUrl
            };

            return View("Index", model);
        }
    }

    public class ItemLinkViewModel
    {
        public string ImageUrl { get; set; }
    }
}