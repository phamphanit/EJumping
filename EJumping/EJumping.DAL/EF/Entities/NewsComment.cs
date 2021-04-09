using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class NewsComment
    {
        public NewsComment()
        {
            NewsCommentReport = new HashSet<NewsCommentReport>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public long NewsId { get; set; }
        public int Status { get; set; }
        public DateTime? LastReportedAt { get; set; }
        public DateTime? HiddenAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Content { get; set; }
        public string HiddenReason { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedById { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<NewsCommentReport> NewsCommentReport { get; set; }
    }
}
