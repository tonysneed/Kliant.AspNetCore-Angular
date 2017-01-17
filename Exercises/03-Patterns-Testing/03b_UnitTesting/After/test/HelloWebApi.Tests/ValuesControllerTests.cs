using System.Linq;
using Xunit;
using HelloWebApi.Controllers;
using HelloWebApi.Repositories;
using Moq;

namespace HelloWebApi.Tests
{
    public class ValuesControllerTests
    {
        [Fact]
        public async void GetShouldReturnValues() 
        {
            string[] expected = { "value1", "value2", "value3", "value4", "value5" };
            var valuesRepoMock = new Mock<IValuesRepository>();
            valuesRepoMock.Setup(x => x.GetValues())
                .ReturnsAsync(expected);
            // var repository = new ValuesRepository();
            var repository = valuesRepoMock.Object;

            var controller = new ValuesController(repository);
            var result = await controller.Get();
            var values = result.ToArray();
            Assert.Collection(values, 
                value1 => Assert.Equal(expected[0], value1),
                value2 => Assert.Equal(expected[1], value2),
                value3 => Assert.Equal(expected[2], value3),
                value4 => Assert.Equal(expected[3], value4),
                value5 => Assert.Equal(expected[4], value5)
                );
        }
    }
}
