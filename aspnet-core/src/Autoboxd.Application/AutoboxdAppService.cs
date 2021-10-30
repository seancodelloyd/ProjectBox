using Autoboxd.Localization;
using Volo.Abp.Application.Services;

namespace Autoboxd
{
    /* Inherit your application services from this class.
     */
    public abstract class AutoboxdAppService : ApplicationService
    {
        protected AutoboxdAppService()
        {
            LocalizationResource = typeof(AutoboxdResource);
        }
    }
}
