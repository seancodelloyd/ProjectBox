using System;
using Volo.Abp.Application.Dtos;

namespace Autoboxd.Items
{
    public class ItemDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public int ManufacturedYear { get; set; }
        public int Rating { get; set; }
    }
}