using System;
using System.Collections.Generic;

namespace ConestogaVideoGameStore.Models
{
    public partial class FriendsList
    {
        public int FriendsListId { get; set; }
        public int MemberId { get; set; }
        public int FriendId { get; set; }
    }
}
