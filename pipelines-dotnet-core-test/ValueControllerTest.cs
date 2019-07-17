using System;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using pipelines_dotnet_core_web_api.Controllers;

namespace pipelines_dotnet_core_test
{
    public class ValueControllerTest
    {
        [Fact]
        public async Task GetValuesSuccess()
        {
            // Arrange
            var valuesController = new ValuesController();

            // Act
            var result = await valuesController.Get();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<string>>>(result);
        }
    }
}
