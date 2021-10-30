using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.Comments
{
    public class Comment : AuditedAggregateRoot<Guid>
    {
        public string Value { get; set; }
    }
}
