using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoboxd.Lists
{
    public class CreateUpdateListDto
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        public List<Guid> ListItems { get; set; }

        [Required]
        public string Description { get; set; } = "";
    }
}
