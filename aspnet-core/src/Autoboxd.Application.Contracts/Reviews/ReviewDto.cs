using System;
using Volo.Abp.Application.Dtos;

using Autoboxd.Ratings;
using Autoboxd.Items;
using Volo.Abp.Identity;

namespace Autoboxd.Reviews
{
    public class ReviewDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IdentityUserDto Creator { get; set; }
        public RatingDto Rating { get; set; }
        public ItemDto Item { get; set; }
    }
}
