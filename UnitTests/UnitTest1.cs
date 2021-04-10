using System;
using Xunit;

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
    }
}
