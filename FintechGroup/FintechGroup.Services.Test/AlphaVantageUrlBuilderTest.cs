namespace FintechGroup.Services.Test
{
    public class AlphaVantageUrlBuilderTest
    {
        [Fact]
        public void AlphaVantageUrlBuilder_ConstructsUrlForCompany()
        {
            var sut = new AlphaVantageUrlBuilder();
            const string companyCode = "IBM";

            var result = sut.GetAlphaVitageUrlForCompany(companyCode);

            var expectedUrl = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=D4JB6QOJPCTET81W";
            Assert.Equal(expectedUrl, result);
        }
    }
}