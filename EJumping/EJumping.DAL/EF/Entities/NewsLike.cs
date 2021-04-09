using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class NewsLike
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long NewsId { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
