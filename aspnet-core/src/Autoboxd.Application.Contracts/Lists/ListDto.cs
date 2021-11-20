using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

using Autoboxd.ListItems;
using Volo.Abp.Identity;

namespace Autoboxd.Lists
{
    public class ListDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public ICollection<ListItemDto> ListItems { get; set; }
        public string Description { get; set; }
        public IdentityUserDto Creator { get; set; }
    }
}
