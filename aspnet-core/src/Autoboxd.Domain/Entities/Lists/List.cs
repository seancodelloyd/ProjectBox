using Autoboxd.Items;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.Lists
{
    public class List : AuditedAggregateRoot<Guid>
    {
        public List<Item> Items { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
