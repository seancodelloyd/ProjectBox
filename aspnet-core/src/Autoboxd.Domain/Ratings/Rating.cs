﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.Ratings
{
    public class Rating : AuditedAggregateRoot<Guid>
    {
        public int Value { get; set; }
        public Guid ItemId { get; set; }
        public Guid UserId { get; set; }
    }
}
