namespace FinTechGroup.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string Ticker { get; set; }
        //public ICollection<ExchangeRate> ExchangeRates { get; set; }

        public double SevenDaysAvg { get; set; }

        public double ThirtyDaysAvg { get; set; }

    }
}
