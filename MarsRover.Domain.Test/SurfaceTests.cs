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
    public class SurfaceTests
    {

        [Fact]
        public void TestSurfacePointInside()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(1);
            mockPosition.Setup(x => x.Y).Returns(2);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.N);

            ISurface surface = new Surface(5, 5);
            Assert.True(surface.IsPointInside(mockPosition.Object));
        }

        [Fact]
        public void TestSurfacePointInsideRightEdge()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(5);
            mockPosition.Setup(x => x.Y).Returns(5);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.N);

            ISurface surface = new Surface(5, 5);
            Assert.True(surface.IsPointInside(mockPosition.Object));
        }

        [Fact]
        public void TestSurfacePointInsideLeftEdge()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(0);
            mockPosition.Setup(x => x.Y).Returns(0);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.N);

            ISurface surface = new Surface(5, 5);
            Assert.True(surface.IsPointInside(mockPosition.Object));
        }

        [Fact]
        public void TestSurfacePointOutside()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(6);
            mockPosition.Setup(x => x.Y).Returns(3);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.N);

            ISurface surface = new Surface(5, 5);
            Assert.False(surface.IsPointInside(mockPosition.Object));
        }


        [Fact]
        public void TestSurfacePointOutsideNegative()
        {
            Mock<IPosition> mockPosition = new Mock<IPosition>();
            mockPosition.Setup(x => x.X).Returns(-1);
            mockPosition.Setup(x => x.Y).Returns(3);
            mockPosition.Setup(x => x.Orientation).Returns(DirectionEnum.N);

            ISurface surface = new Surface(5, 5);
            Assert.False(surface.IsPointInside(mockPosition.Object));
        }
    }
}