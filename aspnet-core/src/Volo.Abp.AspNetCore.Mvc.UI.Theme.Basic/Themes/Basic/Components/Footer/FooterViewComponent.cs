using Microsoft.AspNetCore.Mvc;

namespace Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Themes.Basic.Components.Footer
{
    public class FooterViewComponent : AbpViewComponent
    {
        public virtual IViewComponentResult Invoke()
        {
            return View("~/Themes/Basic/Components/Footer/Default.cshtml");
        }
    }
}
