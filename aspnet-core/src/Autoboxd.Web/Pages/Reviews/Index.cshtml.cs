using Autoboxd.Items;
using Autoboxd.Lists;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Autoboxd.Web.Pages.Reviews
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

        public async Task OnGetAsync(string username, string title)
        {
        }
    }
}
