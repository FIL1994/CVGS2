using System;
using System.Collections.Generic;

namespace ConestogaVideoGameStore.Models
{
    public partial class MemberEvents
    {
        public int EventId { get; set; }
        public DateTime DateAndTime { get; set; }
        public int RegisteredMembersId { get; set; }
        public string EDescription { get; set; }
    }
}
