using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;

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
