using System.Security.Cryptography.X509Certificates;
using Core.Entities;

namespace Core.Specifications
{
    public class BanksWithCardProductSpecification : BaseSpecification<Bank>
    {
        public BanksWithCardProductSpecification()
        {
            AddInclude(x => x.CardProducts);
        }
        public BanksWithCardProductSpecification(int id):base(x => x.Id == id)
        {
             AddInclude(x => x.CardProducts);
        }
    }
}