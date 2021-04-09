using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class PbGamebetWs
    {
        public long BetId { get; set; }
        public DateTime GameDate { get; set; }
        public long UserId { get; set; }
        public long BetBall { get; set; }
        public decimal HitOdds { get; set; }
        public long HitBall { get; set; }
        public int IsProvide { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime StartDate { get; set; }
        public long GameRoundId { get; set; }
        public int BetPbOddEven { get; set; }
        public int BetPbPrediction { get; set; }
        public int BetPbUnderOver { get; set; }
        public int BetRbSumLowHighMedium { get; set; }
        public int BetRbSumLowHighMediumOddEven { get; set; }
        public int BetRbSumOddEven { get; set; }
        public int BetRbSumUnderOver { get; set; }
        public int BetRbSumUnderOverOddEven { get; set; }
    }
}
