using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

using Autoboxd.ListItems;
using Volo.Abp.Identity;

namespace Autoboxd.Lists
{
    public class List : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public ICollection<ListItem> ListItems { get; set; }

        public List(string title, string description)
        {
            Title = title;
            Description = description;
            ListItems = new List<ListItem>();
            Path = title
                .ToKebabCase()
                .Replace(" ", "-");
        }

        protected List() { }
    }
}
