using System;
using System.Collections.Generic;

namespace ConestogaVideoGameStore.Models
{
    public partial class SalesHistory
    {
        public int SalesId { get; set; }
        public int GameId { get; set; }
        public int? PriceAtPurchase { get; set; }
        public int MemberId { get; set; }
    }
}
