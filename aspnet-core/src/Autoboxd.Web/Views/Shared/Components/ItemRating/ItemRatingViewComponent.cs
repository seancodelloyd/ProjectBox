using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autoboxd.Web.Components.ItemRating
{
    [ViewComponent(Name = "ItemRating")]
    public class ItemRatingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(decimal rating)
        {
            var model = new ItemRatingViewModel()
            {
                Rating = rating
            };

            return View("Index", model);
        }
    }

    public class ItemRatingViewModel
    {
        public decimal Rating { get; set; }
    }
}