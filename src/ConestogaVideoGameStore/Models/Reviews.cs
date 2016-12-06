using System;
using System.Collections.Generic;

namespace ConestogaVideoGameStore.Models
{
    public partial class Reviews
    {
        public int ReviewId { get; set; }
        public int GameId { get; set; }
        public int MemberId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
