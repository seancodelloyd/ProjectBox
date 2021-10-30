using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.Items
{
    public class Item : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ManufacturedYear { get; set; }
    }
}
