using MarsRover.Domain.Commands;
using MarsRover.Domain.Enum;
using MarsRover.Domain.Interface;
using Moq;
using Xunit;

namespace MarsRover.Domain.Test
{
    public class CommandCenterTests
    {
        private Mock<IRover> _mockRover;
        private Mock<ISurface> _mockSurface;

        public CommandCenterTests()
        {
            Mock<IPosition> mockInitialPosition = new Mock<IPosition>();
            mockInitialPosition.Setup(x => x.X).Returns(1);
            mockInitialPosition.Setup(x => x.Y).Returns(2);
            mockInitialPosition.Setup(x => x.Orientation).Returns(DirectionEnum.N);

            _mockRover = new Mock<IRover>();
            _mockRover.Setup(x => x.CurrentPosition).Returns(mockInitialPosition.Object);

            _mockSurface = new Mock<ISurface>();
            _mockSurface.Setup(x => x.Width).Returns(5);
            _mockSurface.Setup(x => x.Length).Returns(5);
        }

        [Fact]
        public void TestCommandCenterExecuteCommandA()
        {
            ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
            commandCenter.ExecuteCommands("AAA");
            _mockRover.Verify(x => x.Move(It.IsAny<MoveForwardCommand>()), Times.Never);
        }

        [Fact]
        public void TestCommandCenterExecuteCommandR()
        {
            ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
            commandCenter.ExecuteCommands("RRR");
            _mockRover.Verify(x => x.Move(It.IsAny<RotateRightCommand>()), Times.Exactly(3));
        }


        [Fact]
        public void TestCommandCenterExecuteCommandL()
        {
            ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
            commandCenter.ExecuteCommands("LLL");
            _mockRover.Verify(x => x.Move(It.IsAny<RotateLeftCommand>()), Times.Exactly(3));
        }

        [Fact]
        public void TestCommandCenterExecuteMultipleCommands()
        {
            ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
            commandCenter.ExecuteCommands("ALR");
            _mockRover.Verify(x => x.Move(It.IsAny<MoveForwardCommand>()), Times.Never);
            _mockRover.Verify(x => x.Move(It.IsAny<RotateLeftCommand>()), Times.Once);
            _mockRover.Verify(x => x.Move(It.IsAny<RotateRightCommand>()), Times.Once);
        }

        [Fact]
        public void TestCommandCenterGetStatus()
        {
            _mockSurface.Setup(x => x.IsPointInside(_mockRover.Object.CurrentPosition)).Returns(true);
            ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
            Assert.Equal("1,2,North", commandCenter.GetStatus());
        }

        [Fact]
        public void TestCommandCenterMoveOutsideSurfaceGetStatus()
        {
            _mockSurface.Setup(x => x.IsPointInside(_mockRover.Object.CurrentPosition)).Returns(false);
            ICommandCenter commandCenter = new CommandCenter(_mockRover.Object, _mockSurface.Object);
            Assert.Equal("1,2,North", commandCenter.GetStatus());
        }
    }
}