using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class PbGameroundWs
    {
        public DateTime GameDate { get; set; }
        public long GameRoundId { get; set; }
        public int? Rb1 { get; set; }
        public int? Rb2 { get; set; }
        public int? Rb3 { get; set; }
        public int? Rb4 { get; set; }
        public int? Rb5 { get; set; }
        public int? Pb { get; set; }
        public int RbSumOddBetCount { get; set; }
        public int RbSumEventBetCount { get; set; }
        public int RbSumUnderBetCount { get; set; }
        public int RbSumOverBetCount { get; set; }
        public int PbOddBetCount { get; set; }
        public int PbEventBetCount { get; set; }
        public int PbUnderBetCount { get; set; }
        public int PbOverBetCount { get; set; }
        public int RbSumLowBetCount { get; set; }
        public int RbSumHighBetCount { get; set; }
        public int RbSumMediumBetCount { get; set; }
        public int HitEventId1 { get; set; }
        public int HitEventId2 { get; set; }
        public int HitEventId3 { get; set; }
        public int HitEventId4 { get; set; }
        public int HitEventId5 { get; set; }
        public int IsProvide { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}
