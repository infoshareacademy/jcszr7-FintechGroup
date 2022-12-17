namespace FinTechGroup.Domain
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public double StartPrice { get; set; }
        public double EndPrice { get; set; }
        public DateTime EffectiveDate { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}
