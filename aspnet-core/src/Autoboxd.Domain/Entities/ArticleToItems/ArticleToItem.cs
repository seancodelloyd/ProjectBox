using Autoboxd.Articles;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Autoboxd.ArticleToItems
{
    // MAYBE DELETE?!
    public class ArticleToItem : AuditedAggregateRoot<Guid>
    {
        public Article Article { get; set; }
        public string Content { get; set; }
    }
}
