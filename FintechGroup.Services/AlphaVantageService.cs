using Newtonsoft.Json;
using System.Net.Http.Headers;
using static FintechGroup.Services.AlphaVantageModels;

namespace FintechGroup.Services
{
    public class AlphaVantageService : IAlphaVantageService
    {
        private readonly IAlphaVantageUrlBuilder urlBuilder;

        public AlphaVantageService(IAlphaVantageUrlBuilder urlBuilder)
        {
            this.urlBuilder = urlBuilder;
        }

        public async Task<Root> GetAlphaVantageCompanyRootInfo(string companyCode)
        {
            Root rootData = new Root();

            using (var client = new HttpClient())
            {
                try
                {
                    var baseURL = urlBuilder.GetAlphaVitageUrlForCompany(companyCode);
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage getData = await client.GetAsync(baseURL);

                    if (getData.IsSuccessStatusCode)
                    {
                        string result = getData.Content.ReadAsStringAsync().Result;
                        rootData = JsonConvert.DeserializeObject<Root>(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new HttpRequestException("Error calling AlphaVantage API");
                }
            }

            return rootData;
        }
    }
}