using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autoboxd.Web.Components.ItemLink
{
    [ViewComponent(Name = "ItemLink")]
    public class ItemLinkViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string imageUrl, string path, string name)
        {
            var model = new ItemLinkViewModel()
            {
                ImageUrl = imageUrl,
                Path = path,
                Name = name
            };

            return View("Index", model);
        }
    }

    public class ItemLinkViewModel
    {
        public string ImageUrl { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
    }
}