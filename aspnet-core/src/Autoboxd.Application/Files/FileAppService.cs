using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace Autoboxd.Files
{
    public class FileAppService : ApplicationService, IFileAppService
    {
        private readonly IBlobContainer<FileContainer> _fileContainer;

        public FileAppService(IBlobContainer<FileContainer> fileContainer)
        {
            _fileContainer = fileContainer;
        }

        public async Task SaveBlobAsync(SaveBlobInputDto input)
        {
            var standard = Resize(input.Content);
            var small = Resize(input.Content, 262);
            var tiny = Resize(input.Content, 82);

            await _fileContainer.SaveAsync(input.Name + ".jpg", standard, true);
            await _fileContainer.SaveAsync(input.Name + "-small.jpg", small, true);
            await _fileContainer.SaveAsync(input.Name + "-tiny.jpg", tiny, true);
        }

        public async Task SaveBlobListAsync(List<SaveBlobInputDto> input)
        {
            foreach (var blob in input)
            {
                await SaveBlobAsync(blob);
            }
        }

        public async Task<BlobDto> GetBlobAsync(GetBlobRequestDto input)
        {
            var blob = await _fileContainer.GetAllBytesAsync(input.Name);

            return new BlobDto
            {
                Name = input.Name,
                Content = blob
            };
        }

        public byte[] Resize(byte[] data, int? width = null)
        {
            using (var stream = new MemoryStream(data))
            {
                var image = Image.FromStream(stream);

                width = width ?? image.Width;

                var height = (width.Value * image.Height) / image.Width;

                var thumbnail = image.GetThumbnailImage(width.Value, height, null, IntPtr.Zero);

                using (var thumbnailStream = new MemoryStream())
                {
                    thumbnail.Save(thumbnailStream, ImageFormat.Jpeg);
                    return thumbnailStream.ToArray();
                }
            }

        }
    }
}