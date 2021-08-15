using System.Collections;
using System.Collections.Generic;

namespace Core.Entities
{
    public class CardProduct:BaseEntity
    {
         public string ProductName { get; set; }
        public int ChipId { get; set; }
        public ChipType ChipType { get; set; }
        public string Comment { get; set; }
        public int IinId { get; set; }
        public Iin Iin { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public ICollection<ChipCertification> ChipCertifications { get; set; }
    }
}