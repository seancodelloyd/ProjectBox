using System;
using Volo.Abp.Application.Dtos;

namespace Autoboxd.Ratings
{
    public class RatingDto : AuditedEntityDto<Guid>
    {
        public int Value { get; set; }
        public Guid ItemId { get; set; }
    }
}