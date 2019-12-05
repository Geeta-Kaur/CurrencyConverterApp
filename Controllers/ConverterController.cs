using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConverterAPI.Domain;
using ConverterAPI.Domain.Read;
using ConverterAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConverterAPI.Enums;

namespace ConverterAPI.Controllers
{
    [ApiController]
    [Route("api/converter")]
    public class ConverterController : ControllerBase
    {
        private readonly ILogger<ConverterController> _logger;
        private readonly ICurrencyReader _currencyService;
        private readonly ICountryReader _countryService;
        public ConverterController(ILogger<ConverterController> logger, ICurrencyReader currencyService, ICountryReader countryService)
        {
            _logger = logger;
            _currencyService = currencyService; 
            _countryService = countryService;
        }

        [HttpGet]
        [Route("allcurrencies")]
        public async Task<ActionResult<List<Currency>>> GetCurrencies()
        {
            List<Currency> currencies = await _currencyService.GetCurrenciesAsync();
            return Ok(currencies);
                       
        }

        [HttpGet]
        [Route("allcountries")]
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            List<Country> result =  await _countryService.GetCountriesAsync();            
            return Ok(result);
            
        }

        [HttpGet("convertinputmodel")]        
        [Route("convertcurrency")]
        public async Task<IActionResult> Convert([FromQuery]ConvertInputModel input)
        {
            //validate input
            if(!ValidInput(input))
                return BadRequest("Invalid data");

            decimal exchangeRate = GetCurrentRates(input.ConvertFrom, input.ConvertTo);
            if(exchangeRate == 0)
               return NotFound(); 
           
            decimal result = Math.Round(exchangeRate* input.ValueToConvert, 2);
            Audit audit = new Audit ("Rates checked from "+input.ConvertFrom.ToString()+" to "+ input.ConvertTo.ToString(), DateTime.Now );
            audit.Save();
            return Ok(result);
        }

        private bool ValidInput(ConvertInputModel input){
            if(input == null)
                return false;
            
            if(input.ValueToConvert <= 0)
                return false;

            return true;
        }

        private decimal GetCurrentRates(CurrencyType baseCurrency, CurrencyType currencyToExchange)
         {
             switch (baseCurrency)
             {
                 case CurrencyType.GBP:
                    if(currencyToExchange== CurrencyType.EUR)
                        return 1.16m;
                    if(currencyToExchange== CurrencyType.USD)
                        return 1.60m;
                    if(currencyToExchange== CurrencyType.AUD)
                        return 2m;  
                    break;
                 default:
                    break;
             }
             return 0m;
         }
    }
}
