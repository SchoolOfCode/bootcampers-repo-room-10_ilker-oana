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
        public async Task GetAllBootcampers_WhenCalledWithNoParams_ReturnsDefaultParams()
        {
            //Arrange. Make an instance of controller
            var testData = new List<Bootcamper> { 
                new Bootcamper { Id = 1, Name = "Ben", CatchPhrase = "test" },
                new Bootcamper { Id = 2, Name = "Josh", CatchPhrase = "test" },
                new Bootcamper { Id = 3, Name = "Paul", CatchPhrase = "test" }
            };

            var FakeRepo = new FakeRepo(testData);
            var controller = new BootcamperController(FakeRepo);

            //Act. Call GetAllBootcampers
            var result = await controller.GetAllBootcampers(null);

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task GetAllBootcampers_WhenCalledWithParam_Returns()
        {
            //Arrange. Make an instance of controller
            var testData = new List<Bootcamper> { 
                new Bootcamper { Id = 1, Name = "Ben", CatchPhrase = "test" },
                new Bootcamper { Id = 2, Name = "Josh", CatchPhrase = "test" },
                new Bootcamper { Id = 3, Name = "Josh", CatchPhrase = "This is also a test" },
                new Bootcamper { Id = 4, Name = "Paul", CatchPhrase = "test" }
            };

            var FakeRepo = new FakeRepo(testData);
            var controller = new BootcamperController(FakeRepo);

            //Act. Call GetAllBootcampers
            var result = await controller.GetAllBootcampers("Josh");

            Assert.Equal(2, result.Count);
        }
    }
}
