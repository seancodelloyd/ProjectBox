using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

using Autoboxd.Items;

namespace Autoboxd.Web.Pages.Cars.All
{
    public class IndexModel : PageModel
    {
        public readonly IItemAppService _itemAppService;

        public IEnumerable<ItemDto> Items { get; set; }

        public IndexModel(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        public async Task OnGetAsync()
        {
            var reviewInput = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = 1000 // TODO: Add paging later
            };

            var items = await _itemAppService.GetListAsync(reviewInput);
            Items = items.Items;
        }
    }
}
