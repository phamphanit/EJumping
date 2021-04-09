using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class UserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayname { get; set; }
        public long? UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
