using Autoboxd.Items;
using Autoboxd.Ratings;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.Reviews
{
    public class Review : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Rating Rating { get; set; }
        public Item Item { get; set; }
    }
}
