using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class Level
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? MinExp { get; set; }
        public int? MaxExp { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
