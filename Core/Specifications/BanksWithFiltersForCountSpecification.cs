using Core.Entities;

namespace Core.Specifications
{
    public class BanksWithFiltersForCountSpecification : BaseSpecification<Bank>
    {
        public BanksWithFiltersForCountSpecification(BankSpecParams bankParams) : base(x =>
                           (!bankParams.Id.HasValue || x.Id == bankParams.Id) &&
                           ((string.IsNullOrEmpty(bankParams.Search) ||
                             (x.Name.ToLower().Contains(bankParams.Search)))))
        {

        }
    }
}