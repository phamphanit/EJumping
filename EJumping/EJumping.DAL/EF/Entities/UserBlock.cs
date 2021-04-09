using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class UserBlock
    {
        public long UserId { get; set; }
        public long BlockedUserId { get; set; }
        public DateTime? Created { get; set; }

        public virtual Users BlockedUser { get; set; }
        public virtual Users User { get; set; }
    }
}
