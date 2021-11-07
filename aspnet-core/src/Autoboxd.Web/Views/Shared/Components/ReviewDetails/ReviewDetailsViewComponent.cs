using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autoboxd.Web.Components.ReviewDetails
{
    [ViewComponent(Name = "ReviewDetails")]
    public class ReviewDetailsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string imageUrl, string title, string description, string path, string author)
        {
            var model = new ReviewDetailsViewModel()
            {
                ImageUrl = imageUrl,
                Title = title,
                Description = description,
                Path = path,
                Author = author
            };

            return View("Index", model);
        }
    }

    public class ReviewDetailsViewModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Path { get; set; }
    }
}