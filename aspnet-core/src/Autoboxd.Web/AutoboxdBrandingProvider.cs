using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Autoboxd.Web
{
    [Dependency(ReplaceServices = true)]
    public class AutoboxdBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Autoboxd";
    }
}
