using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Autoboxd.Comments
{
    public interface ICommentAppService : ICrudAppService<
        CommentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCommentDto>
    {
        public Task<PagedResultDto<CommentDto>> GetAllComments(PagedAndSortedResultRequestDto input);
        public Task<PagedResultDto<CommentDto>> GetForEntity(PagedAndSortedResultRequestDto input, Guid entityId);
    }
}
