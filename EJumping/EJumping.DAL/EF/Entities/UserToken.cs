using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class UserToken
    {
        public long UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Users User { get; set; }
    }
}
