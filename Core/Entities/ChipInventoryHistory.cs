using System;
using Core.Entities.enums;

namespace Core.Entities
{
    public class ChipInventoryHistory :BaseEntity
    {
         public RequestType Action { get; set; }

        public int Quantity { get; set; }

        public string Requester { get; set; }

        public string MediatorName { get; set; }

        public string Description { get; set; }

        public bool Approved { get; set; }

        public int ChipInventoryId { get; set; }
        
        public DateTime DateRequested { get; set; }
        public ChipInventory ChipInventory { get; set; }
    }
}