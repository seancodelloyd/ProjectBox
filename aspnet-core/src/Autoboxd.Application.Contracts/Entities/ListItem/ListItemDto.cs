using System;
using Volo.Abp.Application.Dtos;

using Autoboxd.Lists;
using Autoboxd.Items;

namespace Autoboxd.ListItems
{
    public class ListItemDto : AuditedEntityDto<Guid>
    {
        public ListDto List { get;set; }
        public Guid ListId { get; set; }

        public ItemDto Item { get; set; }
        public Guid ItemId { get; set; }
    }
}
