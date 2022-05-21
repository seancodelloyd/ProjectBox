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
        public IEnumerable<string> Models { get; set; }

        public IndexModel(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        public async Task OnGetAsync(string brand = null, int? year = null, string searchTerm = null)
        {
            var reviewInput = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = 1000 // TODO: Add paging later
            };

            var filter = new ItemSearchFilter()
            {
                Brand = brand,
                Year = year,
                SearchTerm = searchTerm
            };

            if (brand == null && year == null && searchTerm == null)
            {
                var models = await _itemAppService.GetBrands();
                Models = models;
            } 
            else
            {
                var items = await _itemAppService.GetFilteredListAsync(reviewInput, filter);
                Items = items.Items;
            }
        }
    }
}
