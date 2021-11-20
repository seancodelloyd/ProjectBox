using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.Comments
{
    public class Comment : AuditedAggregateRoot<Guid>
    {
        public Guid EntityId { get; set; }
        public string Value { get; set; }
    }
}
