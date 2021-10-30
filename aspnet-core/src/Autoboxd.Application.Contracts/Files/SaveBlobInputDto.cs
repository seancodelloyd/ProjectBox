using System.ComponentModel.DataAnnotations;

namespace Autoboxd.Files
{
    public class SaveBlobInputDto
    {
        public byte[] Content { get; set; }

        [Required]
        public string Name { get; set; }
    }
}