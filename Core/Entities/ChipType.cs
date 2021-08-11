using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class ChipType:BaseEntity
    {
        public string Name { get; set; }

        public string LoaReferenceNumber { get; set; }

        public string LoaDirPath { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public List<CardProduct> CardProducts { get; set; }
    }
}