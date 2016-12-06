using System;
using System.Collections.Generic;

namespace ConestogaVideoGameStore.Models
{
    public partial class MemberGameRepository
    {
        public int LibraryId { get; set; }
        public int GameId { get; set; }
        public int MemberId { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
