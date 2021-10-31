using Autoboxd.Items;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Autoboxd.Web.Pages.Cars
{
    public class IndexModel : PageModel
    {
        public readonly IItemService _itemService;

        public IndexModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        public string Name { get; set; }
        public Guid ItemId { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }
        public decimal Rating { get; set; }

        public void OnGet(string title)
        {
            Task<ItemDto> task = Task.Run(() => _itemService.GetByPathAsync(title));
            var item = task.Result;

            ItemId = item.Id;
            Name = item.Name;
            Description = item.Description;
            Year = item.ManufacturedYear;
            ImagePath = "/download/" + item.Path + ".jpg";
            Rating = item.Rating;
        }
    }
}
