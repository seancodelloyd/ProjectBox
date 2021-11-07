using System;
using System.ComponentModel.DataAnnotations;

namespace Autoboxd.ListItems
{
    public class CreateUpdateListItemDto
    {
        [Required]
        public Guid ListId { get; set; }
        [Required]
        public Guid ItemId { get; set; }
    }
}
