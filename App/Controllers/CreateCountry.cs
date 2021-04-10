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
    public class CreateCountryController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] Country country)
        {
            string path = Path.Combine("data", "country.txt");
            System.IO.File.CreateText(path);
            using (StreamWriter sw = System.IO.File.CreateText(path))
            {
                sw.WriteLine($"{{ \"name\": \"{country.name}\", \"code\": \"{country.code}\"}}");
            }
            return $"name: {country.name}, code: {country.code}";
        }
    }
}
