using System.Collections.Generic;
using Core.Entities;

namespace API.Dto
{
    public class BankToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public string UniqueIdentityNumber { get; set; }

        public string Picture { get; set; } 
        public ICollection<BankCardProductDto> CardProducts   { get; set; }
        public ICollection<BankChipHistoryDto> ChipInventories   { get; set; }
    }
}