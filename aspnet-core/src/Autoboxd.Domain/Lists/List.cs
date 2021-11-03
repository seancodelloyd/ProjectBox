using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

using Autoboxd.ListItems;

namespace Autoboxd.Lists
{
    public class List : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<ListItem> ListItems { get; set; }

        public List(string title, string description)
        {
            Title = title;
            Description = description;
            ListItems = new List<ListItem>();
        }

        protected List() { }
    }
}
