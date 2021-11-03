using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.Files
{
    public class File : AuditedAggregateRoot<Guid>
    {
        public byte[] Data { get; set; }
        public EnumFileType Type { get; set; }
    }
}
