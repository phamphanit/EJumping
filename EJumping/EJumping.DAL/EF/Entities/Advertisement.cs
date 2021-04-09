using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class Advertisement
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
