using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Autoboxd.Web.Pages;

namespace Autoboxd.Items
{
    public class CreateModalModel : AutoboxdPageModel
    {
        [BindProperty]
        public CreateUpdateItemDto Item { get; set; }

        private readonly IItemService _itemService;

        public CreateModalModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void OnGet()
        {
            Item = new CreateUpdateItemDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _itemService.CreateAsync(Item);
            return NoContent();
        }
    }
}
