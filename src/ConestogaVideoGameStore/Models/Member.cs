using System;
using System.Collections.Generic;

namespace ConestogaVideoGameStore.Models
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public string DisplayName { get; set; }
        public string MemberPassword { get; set; }
        public int WishlistId { get; set; }
        public int PaymentId { get; set; }
        public int FriendListId { get; set; }
        public int? IsEmployee { get; set; }
    }
}
