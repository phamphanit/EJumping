using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class UserLoginLog
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string RequestIp { get; set; }
        public string UserAgent { get; set; }
        public DateTime? LoginDate { get; set; }

        public virtual Users User { get; set; }
    }
}
