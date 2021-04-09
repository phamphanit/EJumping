using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class Role
    {
        public Role()
        {
            Roleclaim = new HashSet<Roleclaim>();
            UserRole = new HashSet<UserRole>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<Roleclaim> Roleclaim { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
