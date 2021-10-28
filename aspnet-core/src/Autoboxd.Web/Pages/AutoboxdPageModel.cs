using Autoboxd.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Autoboxd.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AutoboxdPageModel : AbpPageModel
    {
        protected AutoboxdPageModel()
        {
            LocalizationResourceType = typeof(AutoboxdResource);
        }
    }
}