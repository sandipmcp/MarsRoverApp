using MarsRover.Domain.Commands;
using MarsRover.Domain.Enum;
using MarsRover.Domain.Interface;
using Moq;
using Xunit;

namespace MarsRover.Domain.Test
{
    public class MoveForwardCommandTests
    {

        [Fact]
        public void TestMoveForwardCommandNorth()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.N);

            var moveCommand = new MoveForwardCommand();
            var newPosition = moveCommand.Execute(mockPosition.Object);

            Assert.Equal(1, newPosition.X);
            Assert.Equal(3, newPosition.Y);
            Assert.Equal(DirectionEnum.N, newPosition.Orientation);
        }

        [Fact]
        public void TestMoveForwardCommandEast()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.E);

            var moveCommand = new MoveForwardCommand();
            var newPosition = moveCommand.Execute(mockPosition.Object);

            Assert.Equal(2, newPosition.X);
            Assert.Equal(2, newPosition.Y);
            Assert.Equal(DirectionEnum.E, newPosition.Orientation);
        }

        [Fact]
        public void TestMoveForwardCommandWest()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.W);

            var moveCommand = new MoveForwardCommand();
            var newPosition = moveCommand.Execute(mockPosition.Object);

            Assert.Equal(0, newPosition.X);
            Assert.Equal(2, newPosition.Y);
            Assert.Equal(DirectionEnum.W, newPosition.Orientation);
        }

        [Fact]
        public void TestMoveForwardCommandSouth()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.S);

            var moveCommand = new MoveForwardCommand();
            var newPosition = moveCommand.Execute(mockPosition.Object);

            Assert.Equal(1, newPosition.X);
            Assert.Equal(1, newPosition.Y);
            Assert.Equal(DirectionEnum.S, newPosition.Orientation);
        }
    }
}