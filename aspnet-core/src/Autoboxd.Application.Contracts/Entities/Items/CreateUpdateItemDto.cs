using System.ComponentModel.DataAnnotations;

namespace Autoboxd.Items
{
    public class CreateUpdateItemDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        // TODO: Needs to be unique
        public string Path { get; set; }

        [Required]
        public string Description { get; set; } = "";

        public int ManufacturerYear { get; set; } = 0;
    }
}
