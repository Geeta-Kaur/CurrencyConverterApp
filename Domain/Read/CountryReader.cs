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
          public async Task<List<Country>> GetCountriesAsync(){
            return await Task.Run(() => GetCountryList());
    }
       
     private List<Country> GetCountryList(){
            return new List<Country>() {
                new Country {
                    Name = "United Kingdom",
                    CurrencyName = Enums.CurrencyType.GBP                    
                },
                new Country {
                    Name = "USA",
                    CurrencyName = Enums.CurrencyType.USD
                },
                new Country {
                    Name = "Australia",
                    CurrencyName = Enums.CurrencyType.AUD
                },
                new Country {
                    Name = "EUROPE",
                    CurrencyName = Enums.CurrencyType.EUR
                }
            };
        }
    }
}
