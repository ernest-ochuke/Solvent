using System;

namespace Core.Entities
{
    public class ChipType:BaseEntity
    {
        public string Name { get; set; }

        public string LoaReferenceNumber { get; set; }

        public string LoaDirPath { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}