using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

using Autoboxd.ListItems;

namespace Autoboxd.Lists
{
    public class List : AuditedAggregateRoot<Guid>
    {
        public List<ListItem> ItemIds { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
