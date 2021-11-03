using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Autoboxd.Web.Pages;

namespace Autoboxd.Items
{
    public class CreateModalModel : AutoboxdPageModel
    {
        [BindProperty]
        public CreateUpdateItemDto Item { get; set; }

        private readonly IItemAppService _itemAppService;

        public CreateModalModel(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        public void OnGet()
        {
            Item = new CreateUpdateItemDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _itemAppService.CreateAsync(Item);
            return NoContent();
        }
    }
}
