using ConverterAPI.Enums;

namespace ConverterAPI.Models
{
    public class ConvertInputModel{
        public CurrencyType ConvertFrom {get;set;}
        public CurrencyType ConvertTo {get;set;}
        public decimal ValueTo {get;set;}
        public decimal ValueFrom {get;set;}


    }
}