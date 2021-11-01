using System;
using Volo.Abp.Domain.Entities.Auditing;

using Autoboxd.Items;
using Autoboxd.Lists;

namespace Autoboxd.ListItems
{
    public class ListItem : AuditedAggregateRoot<Guid>
    {
        public List List { get; set; }
        public Guid ListId { get; set; }

        public Item Item { get; set; }
        public Guid ItemId { get; set; }
    }
}
