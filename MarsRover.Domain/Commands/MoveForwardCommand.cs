
using MarsRover.Domain.Concrete;
using MarsRover.Domain.Enum;
using MarsRover.Domain.Interface;

namespace MarsRover.Domain.Commands
{
    /// <summary>
    /// An <see cref="IMoveCommand"/> to advance forward from the current position.
    /// </summary>
    public class MoveForwardCommand : IMoveCommand
    {
        public IPosition Execute(IPosition currentPosition)
        {
            switch (currentPosition.Orientation)
            {
                case DirectionEnum.N:
                    return new Position(currentPosition.X, currentPosition.Y + 1, currentPosition.Orientation);
                case DirectionEnum.E:
                    return new Position(currentPosition.X + 1, currentPosition.Y, currentPosition.Orientation);
                case DirectionEnum.S:
                    return new Position(currentPosition.X, currentPosition.Y - 1, currentPosition.Orientation);
                default:
                    return new Position(currentPosition.X - 1, currentPosition.Y, currentPosition.Orientation);
            }
        }
    }
}

