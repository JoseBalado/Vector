using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var controller = new App.Controllers.CountriesController();
            var result = controller.Get();
            Assert.True(result.Length > 0);
        }

        [Theory]
        [InlineData("es")]
        public void Test2(string code)
        {
            var controller = new App.Controllers.CountryNameController();
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
            var controller = new App.Controllers.CreateCountryController();
            var result = controller.Post(country);
            Assert.True(result == $"name: {country.name}, code: {country.code}");
        }
    }
}
