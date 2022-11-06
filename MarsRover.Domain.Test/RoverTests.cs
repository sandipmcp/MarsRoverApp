using MarsRover.Domain.Concrete;
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
    public class RoverTests
    {

        [Fact]
        public void TestRoverCurrentPosition()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.N);

            Rover rover = new Rover(mockPosition.Object);

            Assert.Equal(1, rover.CurrentPosition.X);
            Assert.Equal(2, rover.CurrentPosition.Y);
            Assert.Equal(DirectionEnum.N, rover.CurrentPosition.Orientation);
        }

        [Fact]
        public void TestRoverMove()
        {
            Mock<IPosition> mockInitialPosition = new Mock<IPosition>();
            mockInitialPosition.Setup(x => x.X).Returns(1);
            mockInitialPosition.Setup(x => x.Y).Returns(2);
            mockInitialPosition.Setup(x => x.Orientation).Returns(DirectionEnum.N);

            Mock<IPosition> mockNewPosition = new Mock<IPosition>();
            mockNewPosition.Setup(x => x.X).Returns(2);
            mockNewPosition.Setup(x => x.Y).Returns(3);
            mockNewPosition.Setup(x => x.Orientation).Returns(DirectionEnum.W);

            Mock<IMoveCommand> mockMoveCommand = new Mock<IMoveCommand>();
            mockMoveCommand.Setup(x => x.Execute(mockInitialPosition.Object)).Returns(mockNewPosition.Object);

            Rover rover = new Rover(mockInitialPosition.Object);
            rover.Move(mockMoveCommand.Object);

            Assert.Equal(2, rover.CurrentPosition.X);
            Assert.Equal(3, rover.CurrentPosition.Y);
            Assert.Equal(DirectionEnum.W, rover.CurrentPosition.Orientation);
        }
    }
}