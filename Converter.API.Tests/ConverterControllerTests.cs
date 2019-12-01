using Xunit;
using AutoFixture;
using FakeItEasy;
using ConverterAPI.Controllers;
using ConverterAPI.Domain.Read;
using Microsoft.Extensions.Logging;
using ConverterAPI.Domain;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
namespace Converter.API.Tests{

    public class ConverterControllerTests{

        //Fakes
        private readonly ICurrencyReader currencyService;
        private readonly ICountryReader countryService;
        private readonly ILogger<ConverterController> logger;
        //Dummy Data Generator
        private readonly Fixture fixture;
        
        //System under test
        private readonly ConverterController sut;
        public ConverterControllerTests()
        {
           logger = A.Fake<ILogger<ConverterController>>();
           currencyService = A.Fake<ICurrencyReader>();
           countryService = A.Fake<ICountryReader>();
           var sut = new ConverterController(logger, currencyService,countryService);

           fixture = new Fixture();
        }

        [Fact]
        public void Given_Ctor_Null_Then_ArgumentNullException()
        {            
            
          Assert.Throws<ArgumentNullException>(() => new ConverterController(null, null, null));          

        }        

         [Fact]
        public void When_GetCurrencies_then_Returns_With200StatusCode()
        {
            //Arrange
            var currencies = new List<Currency> {new Currency("GBP","Pounds")};              

            //Act

            A.CallTo(() => currencyService.GetCurrenciesAsync()).Returns(currencies);

            //Act
            var result = sut.GetCurrencies();


            //Assert
            A.CallTo(() => currencyService.GetCurrenciesAsync()).MustHaveHappenedOnceExactly();
            Assert.IsType<Task<ActionResult<List<Currency>>>>(result);
            Assert.NotNull(result);
            //Assert.Equal(currencies.Count, result.Count());

        } 
        [Fact]
        public void When_GetCurrencies_Then_Returns_ListOfCurrency()
        {
            //Arrange
            var currencies = fixture.CreateMany<Currency>(3);
             

            //Act


            //Assert

        }
        [Fact]
        public void When_GetCountries_Then_Returns_With200StatusCode()
        {
            //Arrange            
            var countries = fixture.CreateMany<Country>(3);   

            //Act


            //Assert

        }


        [Fact]
        public void When_GetCountries_Then_Returns_ListOfCountry()
        {
            //Arrange            
            var countries = fixture.CreateMany<Country>(3);   

            //Act


            //Assert

        }

        [Fact]
        public void When_Convert_InValid_Params_Then_Response400BadRequest()
        {
            //Arrange


            //Act


            //Assert
        }

        [Fact]
        public void When_Convert_Valid_Params_Then_Response200OK()
        {
            //Arrange
            var currencies = fixture.CreateMany<Currency>(3);
            var countries = fixture.CreateMany<Country>(3);

            //Act


            //Assert
        }

    }
}