using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Autoboxd.Items;
using Autoboxd.Web.Pages;

namespace Autoboxd.Web.Pages.Items
{
    public class EditModalModel : AutoboxdPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateItemDto Item { get; set; }

        private readonly IItemAppService _itemAppService;

        public EditModalModel(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        public async Task OnGetAsync()
        {
            var itemDto = await _itemAppService.GetAsync(Id);
            Item = ObjectMapper.Map<ItemDto, CreateUpdateItemDto>(itemDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _itemAppService.UpdateAsync(Id, Item);
            return NoContent();
        }
    }
}