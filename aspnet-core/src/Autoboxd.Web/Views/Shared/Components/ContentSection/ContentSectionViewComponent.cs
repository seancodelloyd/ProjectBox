using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Autoboxd.Web.Components.ContentSection
{
    [ViewComponent(Name = "ContentSection")]
    public class ContentSectionViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string title, string link, string linkText = "More", bool hasRule = true)
        {
            var model = new ContentSectionViewModel()
            {
                Title = title,
                Link = link,
                LinkText = linkText,
                HasRule = hasRule
            };

            return View("Index", model);
        }
    }

    public class ContentSectionViewModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string LinkText { get; set; }
        public bool HasRule { get; set; }
    }
}