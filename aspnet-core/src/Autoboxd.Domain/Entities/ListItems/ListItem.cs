﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.ListItems
{
    public class ListItem : AuditedAggregateRoot<Guid>
    {
        public Guid ListId { get; set; }
        public Guid ItemId { get; set; }
    }
}
