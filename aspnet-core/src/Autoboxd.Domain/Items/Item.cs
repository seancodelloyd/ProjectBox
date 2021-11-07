using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;

using Autoboxd.ListItems;
using Autoboxd.Reviews;

namespace Autoboxd.Items
{
    public class Item : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public int ManufacturedYear { get; set; }
        public bool IsFeatured { get; set; }
        public List<Review> Reviews { get; set; }

        public ICollection<ListItem> ListItems { get; set; }

        public Item(
            Guid id,
            [NotNull] string name,
            [NotNull] string path,
            [NotNull] string description,
            int manufacturedYear,
            bool isFeatured) : base(id)
        {
            ChangeName(name);
            Path = path;
            Description = description;
            ManufacturedYear = manufacturedYear;
            IsFeatured = isFeatured;
            Reviews = new List<Review>();
        }

        private Item() { }

        internal Item ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: ItemConsts.MaxNameLength
            );
        }
    }
}
