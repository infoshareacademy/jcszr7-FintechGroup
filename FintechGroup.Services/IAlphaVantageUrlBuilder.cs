namespace FintechGroup.Services
{
    public interface IAlphaVantageUrlBuilder
    {
        string GetAlphaVitageUrlForCompany(string companyCode);
    }
}