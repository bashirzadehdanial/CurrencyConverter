using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyConverterApp
{
    public class CurrencyConverter
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<decimal> ConvertCurrency(decimal amount, string baseCurrency, string targetCurrency)
        {
            decimal rate = await GetExchangeRate(baseCurrency, targetCurrency);
            return amount * rate;
        }

        private async Task<decimal> GetExchangeRate(string baseCurrency, string targetCurrency)
        {
            string url = $"https://api.exchangeratesapi.io/latest?access_key=YOUR_API_KEY&base={baseCurrency}&symbols={targetCurrency}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ExchangeRateResult>(responseBody);
            return result.Rates[targetCurrency];
        }
    }
}
