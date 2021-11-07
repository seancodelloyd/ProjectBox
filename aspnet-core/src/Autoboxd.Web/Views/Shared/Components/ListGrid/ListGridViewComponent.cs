using Autoboxd.Lists;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoboxd.Web.Components.ListGrid
{
    [ViewComponent(Name = "ListGrid")]
    public class ListGridViewComponent : ViewComponent
    {
        private readonly IListAppService _listAppService;
        public ListGridViewComponent(IListAppService listAppService)
        {
            _listAppService = listAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync(ListDto listDto)
        {
            var images = listDto.ListItems
                .OrderBy(li => li.CreationTime)
                .Take(4)
                .ToList();
                
            var imagePaths = images
                .Select(li => li.Item.Path + "-tiny.jpg")
                .ToList();

            var model = new ListGridViewModel()
            {
                Path = "/List/", // TODO: Add path here!
                Title = listDto.Title,
                Description = listDto.Description,
                ImagePaths = imagePaths,
                Author = listDto.Creator.UserName
            };

            return View("Index", model);
        }
    }

    public class ListGridViewModel
    {
        public List<string> ImagePaths { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}