using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autoboxd.Web.Components.ItemLink
{
    [ViewComponent(Name = "ItemLink")]
    public class ItemLinkViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string imageUrl, string brand, string path, string name, int year)
        {
            var model = new ItemLinkViewModel()
            {
                ImageUrl = imageUrl,
                Brand = brand,
                Path = path,
                Name = name,
                Year = year.ToString()
            };

            return View("Index", model);
        }
    }

    public class ItemLinkViewModel
    {
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
    }
}