using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class EmailVerification
    {
        public long Id { get; set; }
        public string RecipientEmail { get; set; }
        public bool? IsSent { get; set; }
        public string VerificationCode { get; set; }
        public DateTime? Requested { get; set; }
        public DateTime? Expired { get; set; }
        public DateTime? LastFailed { get; set; }
        public int? NumFailed { get; set; }
        public string IpAddress { get; set; }
    }
}
