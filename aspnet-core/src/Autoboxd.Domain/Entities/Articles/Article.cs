using Autoboxd.Items;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.Articles
{
    public class Article : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public List<Item> AssociatedItems { get; set; }
    }
}
