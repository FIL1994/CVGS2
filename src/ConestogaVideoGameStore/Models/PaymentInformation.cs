using System;
using System.Collections.Generic;

namespace ConestogaVideoGameStore.Models
{
    public partial class PaymentInformation
    {
        public int PaymentId { get; set; }
        public string PayType { get; set; }
        public int CardNumber { get; set; }
        public int Csc { get; set; }
    }
}
