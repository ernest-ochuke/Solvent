using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class ChipInventory :BaseEntity
    {
         public ChipType ChipType { get; set; }

        public int Quantity { get; set; }

        public DateTime? DateEntered { get; set; }

        public int CurrentBalance { get; set; }
        public string KCV { get; set; }

        public ICollection<ChipInventoryHistory> History {get;set;}
    }
}