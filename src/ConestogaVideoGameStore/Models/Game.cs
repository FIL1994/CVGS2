using System;
using System.Collections.Generic;

namespace ConestogaVideoGameStore.Models
{
    public partial class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Genre { get; set; }
        public int Esrb { get; set; }
        public int SalesDiscountId { get; set; }
    }
}
