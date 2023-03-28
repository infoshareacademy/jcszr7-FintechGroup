namespace FintechGroup.Services.Test
{
    public class AlphaVantageServiceTest
    {
        [Fact]
        public async Task GetAlphaVantageCompanyRootInfo_ReturnsComapnyRootInfo()
        {
            var sut = new AlphaVantageService(new AlphaVantageUrlBuilder());

            var result = await sut.GetAlphaVantageCompanyRootInfo("IBM");

            Assert.NotNull(result);
            Assert.NotEmpty(result.TimeSeries5min);
        }

        [Fact]
        public async Task GetAlphaVantageCompanyRootInfo_ThrowsErroOnIncorrectUrl()
        {
            var sut = new AlphaVantageService(new ErrorUrlBuilderStub());

            Assert.ThrowsAsync<HttpRequestException>(async () => await sut.GetAlphaVantageCompanyRootInfo("IBM"));
        }
    }

    internal class ErrorUrlBuilderStub : IAlphaVantageUrlBuilder
    {
        public string GetAlphaVitageUrlForCompany(string companyCode)
        {
            throw new Exception();
        }
    }
}