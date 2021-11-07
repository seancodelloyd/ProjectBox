using System;
using System.ComponentModel.DataAnnotations;

namespace Autoboxd.Reviews
{
    public class CreateUpdateReviewDto
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; } = "";

        [Required]
        public Guid ItemId { get; set; }
    }
}
