namespace FintechGroup.Services
{
    public interface IAlphaVantageService
    {
        Task<AlphaVantageModels.Root> GetAlphaVantageCompanyRootInfo(string companyCode);
    }
}