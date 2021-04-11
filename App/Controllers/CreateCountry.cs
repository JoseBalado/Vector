using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateCountryController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public CreateCountryController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        public string Post([FromBody] Country country)
        {
            var directory = Configuration["Directory"];
            var createCountryfileName = Configuration["CreateCountryFileName"];
            string path = Path.Combine(directory, createCountryfileName);
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine($"{{ \"name\": \"{country.name}\", \"code\": \"{country.code}\"}}");
            }
            return $"name: {country.name}, code: {country.code}";
        }
    }
}
