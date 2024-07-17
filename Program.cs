using System;
using System.Threading.Tasks;

namespace CurrencyConverterApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Currency Converter!");
            Console.WriteLine("Example currencies: USD, EUR, GBP");
            Console.Write("Enter the base currency: ");
            string baseCurrency = Console.ReadLine().ToUpper();

            Console.Write("Enter the target currency: ");
            string targetCurrency = Console.ReadLine().ToUpper();

            Console.Write("Enter the amount to convert: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            CurrencyConverter converter = new CurrencyConverter();
            decimal convertedAmount = await converter.ConvertCurrency(amount, baseCurrency, targetCurrency);

            Console.WriteLine($"{amount} {baseCurrency} is {convertedAmount} {targetCurrency}.");
        }
    }
}
