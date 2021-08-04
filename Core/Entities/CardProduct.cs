namespace Core.Entities
{
    public class CardProduct:BaseEntity
    {
         public string ProductName { get; set; }

      
        public int ChipCertificationId { get; set; }
        public ChipCertification ChipCertification { get; set; }

       
        public int ChipId { get; set; }
        public ChipType ChipType { get; set; }
        public string Comment { get; set; }
       
        public int BankId { get; set; }
        public Bank Bank { get; set; }
    }
}