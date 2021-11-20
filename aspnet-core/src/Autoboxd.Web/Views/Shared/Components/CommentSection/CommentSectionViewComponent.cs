using Autoboxd.Comments;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Autoboxd.Web.Components.CommentSection
{
    [Widget(RefreshUrl = "/Widgets/Comments")]
    public class CommentSectionViewComponent : AbpViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<CommentDto> comments)
        {
            var model = new CommentSectionViewModel()
            {
                Comments = comments
            };

            return View("Index", model);
        }
    }

    public class CommentSectionViewModel
    {
        public IEnumerable<CommentDto> Comments { get; set; }
    }
}