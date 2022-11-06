using MarsRover.Domain.Commands;
using MarsRover.Domain.Enum;
using MarsRover.Domain.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarsRover.Domain.Test
{
    public class RotateRightCommandTests
    {

        [Fact]
        public void RotateRightCommandNorth()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.N);

            var rotateCommand = new RotateRightCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.Equal(1, newPosition.X);
            Assert.Equal(2, newPosition.Y);
            Assert.Equal(DirectionEnum.E, newPosition.Orientation);
        }

        [Fact]
        public void RotateRightCommandEast()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.E);

            var rotateCommand = new RotateRightCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.Equal(1, newPosition.X);
            Assert.Equal(2, newPosition.Y);
            Assert.Equal(DirectionEnum.S, newPosition.Orientation);
        }

        [Fact]
        public void RotateRightCommandSouth()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.S);

            var rotateCommand = new RotateRightCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.Equal(1, newPosition.X);
            Assert.Equal(2, newPosition.Y);
            Assert.Equal(DirectionEnum.W, newPosition.Orientation);
        }

        [Fact]
        public void RotateRightCommandWest()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.W);

            var rotateCommand = new RotateRightCommand();
            var newPosition = rotateCommand.Execute(mockPosition.Object);

            Assert.Equal(1, newPosition.X);
            Assert.Equal(2, newPosition.Y);
            Assert.Equal(DirectionEnum.N, newPosition.Orientation);
        }
    }
}