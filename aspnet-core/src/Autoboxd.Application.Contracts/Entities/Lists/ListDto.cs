using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

using Autoboxd.ListItems;

namespace Autoboxd.Lists
{
    public class ListDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public ICollection<ListItemDto> ListItems { get; set; }
        public string Description { get; set; }
    }
}
