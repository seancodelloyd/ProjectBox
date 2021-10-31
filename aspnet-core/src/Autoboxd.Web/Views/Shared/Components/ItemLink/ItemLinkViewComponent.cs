using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autoboxd.Web.Components.ItemLink
{
    [ViewComponent(Name = "ItemLink")]
    public class ItemLinkViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string imageUrl, string path)
        {
            var model = new ItemLinkViewModel()
            {
                ImageUrl = imageUrl,
                Path = path
            };

            return View("Index", model);
        }
    }

    public class ItemLinkViewModel
    {
        public string ImageUrl { get; set; }
        public string Path { get; set; }
    }
}