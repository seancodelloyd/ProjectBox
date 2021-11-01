using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

using Autoboxd.ListItems;

namespace Autoboxd.Lists
{
    public class List : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<ListItem> ListItems { get; set; }
    }
}
