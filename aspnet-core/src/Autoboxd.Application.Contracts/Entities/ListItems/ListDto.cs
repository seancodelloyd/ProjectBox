using System;
using Volo.Abp.Application.Dtos;

namespace Autoboxd.ListItems
{
    public class ListItemDto : AuditedEntityDto<Guid>
    {
        public Guid ListId { get; set; }
        public Guid ItemId { get; set; }
    }
}
