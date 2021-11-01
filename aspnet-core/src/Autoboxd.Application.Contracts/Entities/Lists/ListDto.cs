using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

using Autoboxd.Items;

namespace Autoboxd.Lists
{
    public class ListDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public List<ItemDto> Items { get; set; }
        public string Description { get; set; }
    }
}
