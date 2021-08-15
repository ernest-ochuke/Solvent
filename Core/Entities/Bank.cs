using System.Collections.Generic;

namespace Core.Entities
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; }
      
        public string UniqueIdentityNumber { get; set; }

        public string ImageUrl { get; set; } 
        public ICollection<CardProduct> CardProducts   { get; set; }
        public ICollection<ChipInventory> ChipInventories   { get; set; }
    }
}