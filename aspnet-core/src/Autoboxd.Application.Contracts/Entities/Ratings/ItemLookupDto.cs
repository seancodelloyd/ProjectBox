using System;
using Volo.Abp.Application.Dtos;

namespace Autoboxd.Ratings
{
    public class ItemLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
