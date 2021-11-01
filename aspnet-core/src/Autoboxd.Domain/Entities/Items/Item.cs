using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

using Autoboxd.ListItems;

namespace Autoboxd.Items
{
    public class Item : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public int ManufacturedYear { get; set; }
        public bool IsFeatured { get; set; }

        public ICollection<ListItem> ListItems { get; set; }
    }
}
