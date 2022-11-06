using MarsRover.Domain.Commands;
using MarsRover.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarsRover.Domain.Test
{
    public class CommandFactoryTests
    {

        [Fact]
        public void TestTryGetMoveForwardCommand()
        {
            Assert.True(CommandFactory.TryGetCommand('F', out IMoveCommand moveCommand));
            Assert.IsType<MoveForwardCommand>(moveCommand);
        }

        [Fact]
        public void TestTryGetRotateLeftCommand()
        {
            Assert.True(CommandFactory.TryGetCommand('L', out IMoveCommand moveCommand));
            Assert.IsType<RotateLeftCommand>(moveCommand);
        }
        [Fact]
        public void TestTryGetRotateRightCommand()
        {
            Assert.True(CommandFactory.TryGetCommand('R', out IMoveCommand moveCommand));
            Assert.IsType<RotateRightCommand>(moveCommand);
        }

        [Fact]
        public void TestTryGetInvalidCommand()
        {
            Assert.False(CommandFactory.TryGetCommand('Z', out IMoveCommand moveCommand));
            Assert.Null(moveCommand);
        }
    }
}