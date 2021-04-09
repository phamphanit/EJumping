using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class DiceRound
    {
        public long Id { get; set; }
        public long Timestamp { get; set; }
        public int RoundNumber { get; set; }
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public DateTime RoundDate { get; set; }
    }
}
