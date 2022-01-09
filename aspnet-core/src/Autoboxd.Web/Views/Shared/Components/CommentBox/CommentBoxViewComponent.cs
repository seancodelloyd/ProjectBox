using Autoboxd.Comments;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Autoboxd.Web.Components.CommentBox
{
    public class CommentBoxViewComponent : AbpViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CommentDto comment)
        {
            var model = new CommentBoxViewModel()
            {
                Comment = comment,
            };

            return View("Index", model);
        }
    }

    public class CommentBoxViewModel
    {
        public CommentDto Comment { get; set; }
    }
}