using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace pipelines_dotnet_core_test
{
    public class pipelines_dotnet_core_tests
    {
        IConfiguration Configuration { get; set; }
        private readonly IWebDriver _driver;

        public pipelines_dotnet_core_tests()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddUserSecrets<pipelines_dotnet_core_tests>();
            Configuration = builder.Build();

            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void TestHomePage()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:44315/");

            Assert.Equal("Home Page - pipelines_dotnet_core", _driver.Title);
            //Assert.Contains("Please provide a new employee data", _driver.PageSource);
        }
    }
}
