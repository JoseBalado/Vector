using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Collections;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            string path = Path.Combine("data", "countries.json");
            string readText = System.IO.File.ReadAllText(path);
            return readText;
        }
    }
}
