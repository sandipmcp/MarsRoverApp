using MarsRover.Domain.Interface;
using MarsRover.Domain.Model;
using MarsRoverApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace MarsRover.Domain.Test
{
    public class RoverControllerTest
    {
        private Mock<IPositionInputValidator> _mockIPositionInputValidator;
        public RoverControllerTest()
        {           
            _mockIPositionInputValidator = new Mock<IPositionInputValidator>();
        }

        [Fact]
        public void TestSendCommand_FFRFLFLF()
        {
            var controller = new RoverController(_mockIPositionInputValidator.Object);
            var inputString = @"{ ""plateauModel"": { ""width"": 3, ""height"": 4},""coordinateModel"": { ""xCoord"": 1,""yCoord"": 1},""messageCommand"": ""FFRFLFLF"",""direction"": ""N""}";

            var roverModel = JsonConvert.DeserializeObject<RoverModel>(inputString);

            var result = controller.SendCommand(roverModel);
            _mockIPositionInputValidator.Verify(x => x.ValidateInputs(It.IsAny<RoverModel>()), Times.Once);

            var okResult = ((ObjectResult)result.Result).Value;
            Assert.Equal("1,4,West", ((BaseOutputModel)okResult).Result);
        }

        [Fact]
        public void TestSendCommand_MMRMMRMRRM()
        {
            var controller = new RoverController(_mockIPositionInputValidator.Object);
            var inputString = @"{ ""plateauModel"": { ""width"": 5, ""height"": 5},""coordinateModel"": { ""xCoord"": 3,""yCoord"": 3},""messageCommand"": ""FFRFFRFRRF"",""direction"": ""E""}";

            var roverModel = JsonConvert.DeserializeObject<RoverModel>(inputString);

            var result = controller.SendCommand(roverModel);
            _mockIPositionInputValidator.Verify(x => x.ValidateInputs(It.IsAny<RoverModel>()), Times.Once);

            var okResult = ((ObjectResult)result.Result).Value;
            Assert.Equal("5,1,East", ((BaseOutputModel)okResult).Result);
        }


        [Fact]
        public void TestSendCommand_LFLFLFLFF()
        {
            var controller = new RoverController(_mockIPositionInputValidator.Object);
            var inputString = @"{ ""plateauModel"": { ""width"": 5, ""height"": 5},""coordinateModel"": { ""xCoord"": 1,""yCoord"": 2},""messageCommand"": ""LFLFLFLFF"",""direction"": ""N""}";

            var roverModel = JsonConvert.DeserializeObject<RoverModel>(inputString);

            var result = controller.SendCommand(roverModel);
            _mockIPositionInputValidator.Verify(x => x.ValidateInputs(It.IsAny<RoverModel>()), Times.Once);

            var okResult = ((ObjectResult)result.Result).Value;
            Assert.Equal("1,3,North", ((BaseOutputModel)okResult).Result);
        }

        [Fact]
        public void TestSendCommand_LFLFLFLF()
        {
            var controller = new RoverController(_mockIPositionInputValidator.Object);
            var inputString = @"{ ""plateauModel"": { ""width"": 5, ""height"": 5},""coordinateModel"": { ""xCoord"": 1,""yCoord"": 2},""messageCommand"": ""LFLFLLFF"",""direction"": ""N""}";

            var roverModel = JsonConvert.DeserializeObject<RoverModel>(inputString);

            var result = controller.SendCommand(roverModel);
            _mockIPositionInputValidator.Verify(x => x.ValidateInputs(It.IsAny<RoverModel>()), Times.Once);

            var okResult = ((ObjectResult)result.Result).Value;
            Assert.NotEqual("1,3,North", ((BaseOutputModel)okResult).Result);
        }
    }
}
