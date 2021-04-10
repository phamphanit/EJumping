using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Core.Models.User
{
    public class UserEditInformationModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
    }
}
