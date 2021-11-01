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
        public CreateUpdateListDto Item { get; set; }

        private readonly IItemService _itemService;

        public EditModalModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task OnGetAsync()
        {
            var bookDto = await _itemService.GetAsync(Id);
            Item = ObjectMapper.Map<ItemDto, CreateUpdateListDto>(bookDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _itemService.UpdateAsync(Id, Item);
            return NoContent();
        }
    }
}