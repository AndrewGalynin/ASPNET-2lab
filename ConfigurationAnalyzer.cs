namespace WebApplication1
{
    public class ConfigurationAnalyzer : IConfigurationAnalyzer
    {
        private readonly IConfiguration _configuration;

        public ConfigurationAnalyzer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetCompanyWithHighestEmployeeCount()
        {
            try
            {
                var companies = _configuration.GetChildren()
                    .Select(company =>
                    {
                        var employeeCountStr = company["EmployeeCount"];
                        if (employeeCountStr != null)
                        {
                            return new
                            {
                                Name = company.Key,
                                EmployeeCount = int.Parse(employeeCountStr)
                            };
                        }
                        return null; 
                    })
                    .Where(company => company != null) 
                    .OrderByDescending(company => company.EmployeeCount)
                    .FirstOrDefault();

                return companies?.Name;
            }
            catch (FormatException ex)
            {
                return "Помилка парсингу EmployeeCount: " + ex.Message;
            }

        }
    }
}
