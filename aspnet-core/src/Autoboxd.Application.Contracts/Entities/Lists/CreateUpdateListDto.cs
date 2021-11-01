using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoboxd.Lists
{
    public class CreateUpdateListDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public List<Guid> Items { get; set; }

        [Required]
        public string Description { get; set; } = "";
    }
}
