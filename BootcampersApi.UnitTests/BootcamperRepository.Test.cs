using System;
using Xunit;
using BootcampersApi;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BootcampersApi.UnitTests
{
    public class BootcamperControllerTests
    {
        [Fact]
        public async Task GetAllBootcampers_WhenCalledWithNoParams_ReturnsOkObjectResult()
        {
            //Arrange. Make an instance of controller
            var FakeRepo = new FakeRepo();
            var controller = new BootcamperController(FakeRepo);

            //Act. Call GetAllBootcampers
            var result = await controller.GetAllBootcampers(null);

            //Assert. Assert.Something
            // Assert.NotNull(controller);
            Assert.Equal(result.StatusCode);
            // Assert.NotNull(result);

        }

    }
}
