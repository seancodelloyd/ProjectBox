using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Autoboxd.Items;

namespace Autoboxd.Comments
{
    public class CommentDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public Guid EntityId { get; set; }
        public string Value { get; set; }
        public ItemDto Item { get; set; }
        public IdentityUserDto Creator { get; set; }
    }
}