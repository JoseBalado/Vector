using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryNameController : ControllerBase
    {
        [HttpGet]
        public Country Get(string code = "")
        {
            string path = Path.Combine("data", "countries.json");
            string jsonString = System.IO.File.ReadAllText(path);
            List<Country> countries = JsonSerializer.Deserialize<List<Country>>(jsonString);
            return countries.Where(country => country.code == code.ToUpper()).FirstOrDefault();
        }
    }
}
