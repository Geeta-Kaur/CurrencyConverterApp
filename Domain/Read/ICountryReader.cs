using System.Collections.Generic;
using System.Threading.Tasks;
using ConverterAPI.Domain;
using ConverterAPI.Enums;

namespace ConverterAPI.Domain.Read
{
    public interface ICountryReader
    {
       public Task<List<Country>> GetCountriesAsync();
    }
}
