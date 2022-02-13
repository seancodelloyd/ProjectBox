using Autoboxd.Items;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Autoboxd.Comments
{
    public class CommentAppService : CrudAppService<
            Comment,
            CommentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCommentDto>,
            ICommentAppService
    {
        private readonly IRepository<IdentityUser, Guid> _identityUserRepository;
        private readonly IRepository<Item, Guid> _itemRepository;

        public CommentAppService(IRepository<Comment, Guid> repository, 
            IRepository<IdentityUser, Guid> identityUserRepository,
            IRepository<Item, Guid> itemRepository) : base(repository)
        {
            _identityUserRepository = identityUserRepository;
            _itemRepository = itemRepository;
        }

        public async Task<PagedResultDto<CommentDto>> GetAllComments(PagedAndSortedResultRequestDto input)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from comment in queryable
                        join creator in _identityUserRepository on comment.CreatorId equals creator.Id
                        join item in _itemRepository on comment.EntityId equals item.Id
                        select new { comment, creator, item };

            var count = query.Count();

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var commentDtos = queryResult.Select(x =>
            {
                var commentDto = ObjectMapper.Map<Comment, CommentDto>(x.comment);
                var creatorDto = ObjectMapper.Map<IdentityUser, IdentityUserDto>(x.creator);
                var itemDto = ObjectMapper.Map<Item, ItemDto>(x.item);

                commentDto.Creator = creatorDto;
                commentDto.Item = itemDto;

                return commentDto;
            }).ToList();

            return new PagedResultDto<CommentDto>(
                count,
                commentDtos
            );
        }

        public async Task<PagedResultDto<CommentDto>> GetForEntity(PagedAndSortedResultRequestDto input, Guid entityId)
        {
            var queryable = await Repository.GetQueryableAsync();

            var query = from comment in queryable
                        join creator in _identityUserRepository on comment.CreatorId equals creator.Id
                        where comment.EntityId == entityId
                        select new { comment, creator };

            var count = query.Count();

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var commentDtos = queryResult.Select(x =>
            {
                var commentDto = ObjectMapper.Map<Comment, CommentDto>(x.comment);
                var creatorDto = ObjectMapper.Map<IdentityUser, IdentityUserDto>(x.creator);

                commentDto.Creator = creatorDto;

                return commentDto;
            }).ToList();

            return new PagedResultDto<CommentDto>(
                count,
                commentDtos
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"comment.{nameof(Comment.CreationTime)}";
            }

            return $"comment.{sorting}";
        }
    }
}
