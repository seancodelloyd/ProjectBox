using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Autoboxd.Web.Pages.Cars
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public string Title
        {
            get; set;
        }

        public void OnGet(string title)
        {
            Title = title;
        }
    }
}
