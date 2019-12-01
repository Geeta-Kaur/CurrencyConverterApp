using System.Threading.Tasks;
using ConverterAPI.Domain;
using System.Collections.Generic;

namespace ConverterAPI.Domain.Read
{
    public interface ICurrencyReader
    {
        public Task<List<Currency>> GetCurrenciesAsync();
    }
}