using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class UserExpLog
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int ActionType { get; set; }
        public long BeforeValue { get; set; }
        public long ChangeValue { get; set; }
        public long AfterValue { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual Users User { get; set; }
    }
}
