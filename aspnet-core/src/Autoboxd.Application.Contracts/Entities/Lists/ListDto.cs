using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

using Autoboxd.ListItems;

namespace Autoboxd.Lists
{
    public class ListDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public List<ListItemDto> Items { get; set; }
        public string Description { get; set; }
    }
}
