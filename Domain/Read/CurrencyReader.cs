using System.Collections.Generic;
using System.Threading.Tasks;
using ConverterAPI.Domain;
using ConverterAPI.Enums;

namespace ConverterAPI.Domain.Read
{
    public class CurrencyReader: ICurrencyReader
    {
        public async Task<List<Currency>> GetCurrenciesAsync()
        {
             return await Task.Run(() => new List<Currency> {
                 new Currency(CurrencyType.GBP.ToString(), "Pound"),
                 new Currency(CurrencyType.USD.ToString(), "US Dollar"),
                 new Currency(CurrencyType.AUD.ToString(), "Aus Dollar"),
                 new Currency(CurrencyType.EUR.ToString(), "Euro")
             }); 
            
        }
    }
}