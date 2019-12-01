using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConverterAPI.Domain;
using ConverterAPI.Enums;

namespace ConverterAPI.Domain.Read
{
    public class CountryReader : ICountryReader
    {
        ///Gets the list of country        
          public  async Task<List<Country>> GetCountriesAsync(){
            return await Task.Run(() => new List<Country>() {
                new Country {
                    Name = "United Kingdom",
                    CurrencyName = Enums.CurrencyType.GBP,
                    ExchangeRate = 80m
                },
                new Country {
                    Name = "USA",
                    CurrencyName = Enums.CurrencyType.USD,
                    ExchangeRate = 60.05m
                },
                new Country {
                    Name = "Australia",
                    CurrencyName = Enums.CurrencyType.AUD,
                    ExchangeRate = 50.70m
                },
                new Country {
                    Name = "EUROPE",
                    CurrencyName = Enums.CurrencyType.EUR,
                    ExchangeRate = 16.0m
                }
            });
            
        }

        public async Task<Country> GetCountryByCurrencyTypeAsync(CurrencyType currencyType)
        {
            return await Task.Run(()=> new Country {
                    Name = "United Kingdom",
                    CurrencyName = Enums.CurrencyType.GBP,
                    ExchangeRate = 80m
                });
        }
    }
}