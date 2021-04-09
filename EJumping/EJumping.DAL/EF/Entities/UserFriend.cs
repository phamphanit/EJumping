using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class UserFriend
    {
        public long UserId { get; set; }
        public long FriendId { get; set; }
        public int Status { get; set; }
        public DateTime? FriendSince { get; set; }
        public DateTime? Created { get; set; }

        public virtual Users Friend { get; set; }
        public virtual Users User { get; set; }
    }
}
