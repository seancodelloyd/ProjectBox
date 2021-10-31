using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autoboxd.Web.Components.HeroImage
{
    [ViewComponent(Name = "HeroImage")]
    public class HeroImageViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string imageUrl)
        {
            var model = new HeroImageViewModel()
            {
                ImageUrl = imageUrl
            };

            return View("Index", model);
        }
    }

    public class HeroImageViewModel
    {
        public string ImageUrl { get; set; }
    }
}