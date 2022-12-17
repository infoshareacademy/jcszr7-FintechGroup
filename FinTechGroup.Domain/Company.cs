namespace FinTechGroup.Domain
{
    public class Company
    {
        public string CompanyName { get; set; }
        public int Id { get; set; }

        public ICollection<ExchangeRate> ExchangeRates { get; set; }

    }
}
