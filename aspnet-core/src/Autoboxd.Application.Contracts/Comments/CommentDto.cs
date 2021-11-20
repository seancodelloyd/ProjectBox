using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Autoboxd.Comments
{
    public class CommentDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public Guid EntityId { get; set; }
        public string Value { get; set; }
        public IdentityUserDto Creator { get; set; }
    }
}