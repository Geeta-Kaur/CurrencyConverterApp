using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConverterAPI.Domain;
using ConverterAPI.Domain.Read;
using ConverterAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            _currencyService = currencyService?? throw new ArgumentNullException(nameof(currencyService)); 
            _countryService = countryService?? throw new ArgumentNullException(nameof(countryService));
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
        public IActionResult Convert([FromQuery]ConvertInputModel input)
        {
            //validate input
            if(!ValidInput(input))
                return BadRequest();
            var result = 2;
            return Ok(result);
        }
        private bool ValidInput(ConvertInputModel input){
            return true;
        }
    }
}
