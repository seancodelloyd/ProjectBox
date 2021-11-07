using Autoboxd.Lists;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Autoboxd.Web.Pages.Lists.All
{
    public class IndexModel : PageModel
    {
        public readonly IListAppService _listAppService;

        public IEnumerable<ListDto> Lists { get; set; }

        public IndexModel(IListAppService listAppService)
        {
            _listAppService = listAppService;
        }

        public async Task OnGetAsync()
        {
            var listInput = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = 1000 // TODO: Add paging later
            };

            var lists = await _listAppService.GetListAsync(listInput);
            Lists = lists.Items;
        }
    }
}
