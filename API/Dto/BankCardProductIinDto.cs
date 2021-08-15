using System.Collections.Generic;

namespace API.Dto
{
    public class BankCardProductIinDto
    {
        public string Name { get; set; }

        public string Pan { get; set; }

        public ICollection<BankCardProductDto> CardProduct { get; set; }
    }
}