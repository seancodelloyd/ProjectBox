using Autoboxd.Items;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Autoboxd.Web.Pages.Cars
{
    public class IndexModel : PageModel
    {
        public readonly IItemAppService _itemAppService;

        public IndexModel(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        public string Name { get; set; }
        public Guid ItemId { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }
        public decimal Rating { get; set; }

        [TextArea]
        public string Comment { get; set; }

        public void OnGet(string title)
        {
            Task<ItemDto> task = Task.Run(() => _itemAppService.GetByPathAsync(title));
            var item = task.Result;

            ItemId = item.Id;
            Name = item.Name;
            Description = item.Description;
            Year = item.ManufacturedYear;
            ImagePath = "/download/" + item.Path;
            Rating = item.Rating;
        }
    }
}
