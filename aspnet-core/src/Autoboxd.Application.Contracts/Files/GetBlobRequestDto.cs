using System.ComponentModel.DataAnnotations;

namespace Autoboxd.Files
{
    public class GetBlobRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}