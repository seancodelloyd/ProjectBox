using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Autoboxd.Web.Pages;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System.Collections.Generic;

namespace Autoboxd.Lists
{
    public class CreateAndAddModalModel : AutoboxdPageModel
    {
        [BindProperty]
        public CreateAndAddListDto List { get; set; }

        private readonly IListAppService _listAppService;

        public CreateAndAddModalModel(IListAppService listAppService)
        {
            _listAppService = listAppService;
        }

        public void OnGet(Guid itemId)
        {
            List = new CreateAndAddListDto()
            {
                ItemId = itemId
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var createUpdateListDto = new CreateUpdateListDto()
            {
                Title = List.Title,
                Description = List.Description,
                ListItems = new List<Guid>()
            };

            var list = await _listAppService.CreateAsync(createUpdateListDto);

            await _listAppService.AddItem(list.Id, List.ItemId);

            return NoContent();
        }
    }

    public class CreateAndAddListDto
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        
        [HiddenInput]
        public Guid ItemId { get; set; }

        [TextArea]
        public string Description { get; set; } = "";
    }
}
