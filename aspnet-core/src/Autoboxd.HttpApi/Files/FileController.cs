using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Autoboxd.Files
{
    public class FileController : AbpController
    {
        private readonly IFileAppService _fileAppService;

        public FileController(IFileAppService fileAppService)
        {
            _fileAppService = fileAppService;
        }

        [HttpPost]
        [Route("upload/tinymce")]
        public async Task<IActionResult> UploadAsync(string test)
        {
            var fileDto = await _fileAppService.GetBlobAsync(new GetBlobRequestDto { Name = test });

            return File(fileDto.Content, "application/octet-stream", fileDto.Name);
        }

        [HttpGet]
        [Route("download/{fileName}")]
        public async Task<IActionResult> DownloadAsync(string fileName)
        {
            var fileDto = await _fileAppService.GetBlobAsync(new GetBlobRequestDto { Name = fileName });

            return File(fileDto.Content, "application/octet-stream", fileDto.Name);
        }
    }
}