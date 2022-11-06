using MarsRover.Domain.Enum;

namespace MarsRover.Domain.Interface
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
        DirectionEnum Orientation { get; set; }
    }
}