using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Autoboxd.Favourites
{
    public class Favourite : AuditedAggregateRoot<Guid>
    {
        public IdentityUser User { get; set; }
        public bool? Value { get; set; }
    }
}
