namespace API.Dto
{
    public class BankCardProductDto
    {
        public string ProductName { get; set; }
        public string Comment { get; set; }
        public int IinId { get; set; }
        public BankCardProductIinDto Iin { get; set; }
    }
}