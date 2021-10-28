using Autoboxd.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Autoboxd.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AutoboxdController : AbpController
    {
        protected AutoboxdController()
        {
            LocalizationResource = typeof(AutoboxdResource);
        }
    }
}