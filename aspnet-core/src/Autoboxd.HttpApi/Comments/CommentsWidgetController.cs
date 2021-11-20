using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Autoboxd.Comments
{
    [Route("Widgets")]
    public class CountersWidgetController : AbpController
    {
        public ICommentAppService _commentAppService { get; set; }

        public CountersWidgetController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        [HttpGet]
        [Route("Comments")]
        public async Task<IActionResult> RefreshComments(Guid entityId)
        {
            var commentResult = await _commentAppService.GetForEntity(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto(), entityId);

            var comments = commentResult.Items;

            return ViewComponent("CommentSection", new { comments });
        }
    }
}
