using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class FxCandlestickRound
    {
        public long Id { get; set; }
        public long Timestamp { get; set; }
        public int RoundNumber { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public DateTime RoundDate { get; set; }
    }
}
