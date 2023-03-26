using Newtonsoft.Json;

namespace FintechGroup.Services
{
    public class AlphaVantageModels
    {
        public class MetaData
        {
            [JsonProperty("1. Information")]
            public string Information { get; set; }

            [JsonProperty("2. Symbol")]
            public string Symbol { get; set; }

            [JsonProperty("3. Last Refreshed")]
            public string LastRefreshed { get; set; }

            [JsonProperty("4. Interval")]
            public string Interval { get; set; }

            [JsonProperty("5. Output Size")]
            public string OutputSize { get; set; }

            [JsonProperty("6. Time Zone")]
            public string TimeZone { get; set; }
        }

        public class Root
        {
            [JsonProperty("Meta Data")]
            public MetaData MetaData { get; set; }

            [JsonProperty("Time Series (5min)")]
            public Dictionary<DateTime, Rates> TimeSeries5min { get; set; }
        }

        public class Rates
        {
            [JsonProperty("1. open")]
            public double Open { get; set; }

            [JsonProperty("2. high")]
            public double High { get; set; }

            [JsonProperty("3. low")]
            public double Low { get; set; }

            [JsonProperty("4. close")]
            public double Close { get; set; }

            [JsonProperty("5. volume")]
            public double Volume { get; set; }
        }
    }
}
