using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autoboxd.Comments
{
    public class CreateUpdateCommentDto
    {
        [Required]
        public Guid EntityId { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
