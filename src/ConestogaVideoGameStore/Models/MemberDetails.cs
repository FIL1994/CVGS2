using System;
using System.Collections.Generic;

namespace ConestogaVideoGameStore.Models
{
    public partial class MemberDetails
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FavoritePlatform { get; set; }
        public string FavoriteGenre { get; set; }
        public string EmailAddress { get; set; }
        public string MailingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public int? Promotional { get; set; }
    }
}
