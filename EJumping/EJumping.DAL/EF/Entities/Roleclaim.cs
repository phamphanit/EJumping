using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class Roleclaim
    {
        public long Id { get; set; }
        public long? RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual Role Role { get; set; }
    }
}
