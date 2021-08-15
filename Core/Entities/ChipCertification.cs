using System;
using System.Security.Principal;
using Core.Entities.enums;

namespace Core.Entities
{
    public class ChipCertification:BaseEntity
    {
         public CertificationType CertificationType { get; set; }

        public string ParentCertificationrRef { get; set; }

        public string ReferenceNumber { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public int ChipTypeId { get; set; }
        public ChipType ChipType { get; set; }

        public CertificationStatus CertificationStatus  { get; set; }

        public int CardProductId { get; set; }
        public CardProduct CardProduct { get; set; }

    }
}