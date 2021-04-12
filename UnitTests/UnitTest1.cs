using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace UnitTests
{
    public class UnitTest1
    {
        private IConfiguration _config;

        public IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"MyConfig.json", optional: false);
                    _config = builder.Build();
                }

                return _config;
            }
        }

        [Fact]
        public void Test1()
        {
            var controller = new App.Controllers.CountriesController(Configuration);
            var result = controller.Get();
            Assert.True(result.Length > 0);
        }

        [Theory]
        [InlineData("es")]
        public void Test2(string code)
        {
            var controller = new App.Controllers.CountryNameController(Configuration);
            var result = controller.Get(code);
            Assert.True(result.name == "Spain");
        }

        public static IEnumerable<Object[]> Data =>
            new List<Object[]> {
                new object[] {new App.Country { name = "abcde", code = "ab" }}
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Test3(App.Country country)
        {
            var controller = new App.Controllers.CreateCountryController(Configuration);
            var result = controller.Post(country);
            Assert.True(result == $"name: {country.name}, code: {country.code}");
        }

        // Acceptance Test: Check that the path for production is the correct one
        [Fact]
        public void AcceptanceTest()
        {
            var directory = Configuration["Directory"];
            var createCountryfileName = Configuration["CreateCountryFileName"];
            var countriesFileName = Configuration["CountriesFileName"];
            Assert.True(directory == "data");
            Assert.True(createCountryfileName == "country.json");
            Assert.True(countriesFileName == "countries.json");
        }
    }
}
