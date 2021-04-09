using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class UserRole
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Users User { get; set; }
    }
}
