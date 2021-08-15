using System.Collections.Generic;

namespace Core.Entities
{
    public class Iin : BaseEntity
    {
        public string Name { get; set; }

        public string Pan { get; set; }

        public ICollection<CardProduct> CardProduct { get; set; }

    }
}