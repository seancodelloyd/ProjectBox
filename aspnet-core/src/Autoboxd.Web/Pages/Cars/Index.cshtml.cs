using Autoboxd.Comments;
using Autoboxd.Files;
using Autoboxd.Items;
using Autoboxd.Lists;
using Autoboxd.Web.Pages.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Users;

namespace Autoboxd.Web.Pages.Cars
{
    public class IndexModel : PageModel
    {
        public readonly IItemAppService _itemAppService;
        public readonly IListAppService _listAppService;
        public readonly ICommentAppService _commentAppService;
        private readonly IFileAppService _fileAppService;
        private readonly ICurrentUser _currentUser;

        [BindProperty]
        public UploadFileDto UploadFileDto { get; set; }

        public IndexModel(IItemAppService itemAppService, 
            IListAppService listAppService, 
            ICommentAppService commentAppService,
            IFileAppService fileAppService,
            ICurrentUser currentUser)
        {
            _itemAppService = itemAppService;
            _listAppService = listAppService;
            _commentAppService = commentAppService;
            _fileAppService = fileAppService;
            _currentUser = currentUser;
        }

        public string Name { get; set; }
        public string Brand { get; set; }

        public Guid ItemId { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }
        public decimal Rating { get; set; }
        public IEnumerable<ListDto> Lists { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public long CommentCount { get; set; }

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

            var listQuery = await _listAppService.GetListAsync(listInput);

            var lists = listQuery.Items.Where(l => l.CreatorId == _currentUser.Id).ToList();

            ItemId = item.Id;
            Name = item.Name;
            Brand = item.Brand;
            Description = item.Description;
            Year = item.ManufacturedYear;
            ImagePath = "/download/" + item.Path + ".jpg";
            Rating = item.Rating;
            Lists = lists;

            var commentInput = new PagedAndSortedResultRequestDto()
            {
                MaxResultCount = 10
            };

            var comments = await _commentAppService.GetForEntity(commentInput, item.Id);

            Comments = comments.Items;
            CommentCount = comments.TotalCount;
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await UploadFileDto.File.CopyToAsync(memoryStream);

        //        await _fileAppService.SaveBlobAsync(
        //            new SaveBlobInputDto
        //            {
        //                Name = UploadFileDto.Name,
        //                Content = memoryStream.ToArray()
        //            }
        //        );
        //    }

        //    return Page();
        //}
    }
}
