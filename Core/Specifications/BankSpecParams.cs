namespace Core.Specifications
{
    public class BankSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > PageIndex) ? MaxPageSize : value;
        }
        public int? Id { get; set; }
        public string Sort { get; set; }
        public string Uniquenumber { get; set; }

        private string e_search;
        public string Search
        {
            get=>e_search;
            set=>e_search = value.ToLower();
        }
    }
}