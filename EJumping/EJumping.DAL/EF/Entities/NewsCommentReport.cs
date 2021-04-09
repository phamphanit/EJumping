using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class NewsCommentReport
    {
        public long Id { get; set; }
        public long NewsCommentId { get; set; }
        public string Reason { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? ReportedById { get; set; }

        public virtual NewsComment NewsComment { get; set; }
    }
}
