using Autoboxd.Lists;
using Autoboxd.Items;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.ListItems
{
    // MAYBE DELETE?!
    public class ListItem : AuditedAggregateRoot<Guid>
    {
        public List List { get; set; }
        public Item Item { get; set; }
    }
}
