using ConverterAPI.Enums;

namespace ConverterAPI.Domain {
    public class Country {
        public int Id { get; set; }
        public string Name { get; set; }
        public CurrencyType CurrencyName { get; set; }     

    }
}
