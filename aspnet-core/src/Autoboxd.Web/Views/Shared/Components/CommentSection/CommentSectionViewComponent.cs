using Autoboxd.Comments;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace Autoboxd.Web.Components.CommentSection
{
    [Widget(RefreshUrl = "/Widgets/Comments")]
    public class CommentBoxViewComponent : AbpViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<CommentDto> comments, bool showHeader = true)
        {
            var model = new CommentSectionViewModel()
            {
                Comments = comments,
                ShowHeader = showHeader
            };

            return View("Index", model);
        }
    }

    public class CommentSectionViewModel
    {
        public IEnumerable<CommentDto> Comments { get; set; }
        public bool ShowHeader { get; set; }
    }
}