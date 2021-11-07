using Autoboxd.Reviews;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Autoboxd.Web.Pages.Reviews.All
{
    public class IndexModel : PageModel
    {
        public readonly IReviewAppService _reviewAppService;

        public IEnumerable<ReviewDto> Reviews { get; set; }

        public IndexModel(IReviewAppService reviewAppService)
        {
            _reviewAppService = reviewAppService;
        }

        public async Task OnGetAsync()
        {
            var reviewInput = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = 1000 // TODO: Add paging later
            };

            var reviews = await _reviewAppService.GetListAsync(reviewInput);
            Reviews = reviews.Items;
        }
    }
}
