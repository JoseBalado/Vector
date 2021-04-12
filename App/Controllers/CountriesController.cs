using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public CountriesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public string Get()
        {
            var directory = Configuration["Directory"];
            var countriesFileName = Configuration["CountriesFileName"];
            string path = Path.Combine(directory, countriesFileName);
            string readText = System.IO.File.ReadAllText(path);
            return readText;
        }
    }
}
