using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;

namespace Core.Specifications
{
    public class BanksWithCardProductSpecification : BaseSpecification<Bank>
    {
        public BanksWithCardProductSpecification(
           BankSpecParams bankParams) : base(x =>
                          (!bankParams.Id.HasValue || x.Id == bankParams.Id) &&
                          ((string.IsNullOrEmpty(bankParams.Search) ||
                            (x.Name.ToLower().Contains(bankParams.Search)))))
        {
            AddInclude(x => x.CardProducts);
            AddInclude(p => p.ChipInventories);
            AddOrderby(x => x.Name);
            ApplyPaging(bankParams.PageSize * (bankParams.PageIndex - 1),
                        bankParams.PageSize);
            if (!string.IsNullOrEmpty(bankParams.Sort))
            {
                switch (bankParams.Sort)
                {
                    case "name":
                        AddOrderby(x => x.Name);
                        break;
                    case "uniquenumber":
                        AddOrderby(x => x.UniqueIdentityNumber);
                        break;
                    default:
                        AddOrderby(n => n.Name);
                        break;
                }
            }
        }
        public BanksWithCardProductSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.CardProducts);
        }
    }
}