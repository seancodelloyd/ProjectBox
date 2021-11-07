using System;
using System.ComponentModel.DataAnnotations;

namespace Autoboxd.Ratings
{
    public class CreateUpdateRatingDto
    {
        [Required]
        public int Value { get; set; } = 0;

        [Required]
        public Guid ItemId { get; set; }
    }
}
