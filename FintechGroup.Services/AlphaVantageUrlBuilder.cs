using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechGroup.Services
{
    public class AlphaVantageUrlBuilder : IAlphaVantageUrlBuilder
    {
        public string GetAlphaVitageUrlForCompany(string companyCode)
        {
            return $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={companyCode}&interval=5min&apikey=D4JB6QOJPCTET81W";
        }
    }
}
