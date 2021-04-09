using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class UserMessage
    {
        public long Id { get; set; }
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Deleted { get; set; }

        public virtual Users Receiver { get; set; }
        public virtual Users Sender { get; set; }
    }
}
