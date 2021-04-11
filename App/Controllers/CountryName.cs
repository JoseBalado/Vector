using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryNameController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public CountryNameController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public Country Get(string code = "")
        {
            var directory = Configuration["Directory"];
            var createCountryfileName = Configuration["CountriesFileName"];
            string path = Path.Combine(directory, createCountryfileName);
            string jsonString = System.IO.File.ReadAllText(path);
            List<Country> countries = JsonSerializer.Deserialize<List<Country>>(jsonString);
            return countries.Where(country => country.code == code.ToUpper()).FirstOrDefault();
        }
    }
}
