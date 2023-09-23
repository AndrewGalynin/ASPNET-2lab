using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public class HomeController : Controller
    {
        private readonly IConfigurationAnalyzer _configurationAnalyzer;

        public HomeController(IConfigurationAnalyzer configurationAnalyzer)
        {
            _configurationAnalyzer = configurationAnalyzer;
        }
        public IActionResult Index()
        {
            var companyWithHighestEmployeeCount = _configurationAnalyzer.GetCompanyWithHighestEmployeeCount();
        
            return Content($"Company with the highest employee count: {companyWithHighestEmployeeCount}");
        }
    }
}
