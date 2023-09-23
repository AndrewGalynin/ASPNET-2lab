using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public class MyConfigController : Controller
    {
        private readonly IConfiguration _configuration;

        public MyConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult MyConfig()
        {
            var name = _configuration["name"];
            var surname = _configuration["surname"];
            var age = _configuration["age"];
            var country = _configuration["country"];
            var city = _configuration["city"];

            return Content($"Name: {name}, Surname: {surname}, Age: {age}, Country: {country}, City: {city}");
        }
    }
}
