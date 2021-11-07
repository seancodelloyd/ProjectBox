using Autoboxd.Items;
using Autoboxd.Lists;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Autoboxd.Web.Pages.Cars
{
    public class IndexModel : PageModel
    {
        public readonly IItemAppService _itemAppService;
        public readonly IListAppService _listAppService;

        public IndexModel(IItemAppService itemAppService, IListAppService listAppService)
        {
            _itemAppService = itemAppService;
            _listAppService = listAppService;
        }

        public string Name { get; set; }
        public Guid ItemId { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }
        public decimal Rating { get; set; }
        public IEnumerable<ListDto> Lists { get; set; }

        [TextArea]
        public string Comment { get; set; }

        public async Task OnGetAsync(string title)
        {
            var item = await _itemAppService.GetByPathAsync(title);

            // TODO: Get lists for only that user!
            var listInput = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = 1000
            };

            var lists = await _listAppService.GetListAsync(listInput);

            ItemId = item.Id;
            Name = item.Name;
            Description = item.Description;
            Year = item.ManufacturedYear;
            ImagePath = "/download/" + item.Path + ".jpg";
            Rating = item.Rating;
            Lists = lists.Items;
        }
    }
}
