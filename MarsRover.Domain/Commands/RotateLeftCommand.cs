
using MarsRover.Domain.Concrete;
using MarsRover.Domain.Enum;
using MarsRover.Domain.Interface;

namespace MarsRover.Domain.Commands
{
    /// <summary>
    /// An <see cref="IMoveCommand"/> to rotate left from the current position.
    /// </summary>
    public class RotateLeftCommand : IMoveCommand
    {
        public IPosition Execute(IPosition currentPosition)
        {
            switch (currentPosition.Orientation)
            {
                case DirectionEnum.N:
                    return new Position(currentPosition.X, currentPosition.Y, DirectionEnum.W);
                case DirectionEnum.E:
                    return new Position(currentPosition.X, currentPosition.Y, DirectionEnum.N);
                case DirectionEnum.S:
                    return new Position(currentPosition.X, currentPosition.Y, DirectionEnum.E);
                default:
                    return new Position(currentPosition.X, currentPosition.Y, DirectionEnum.S);
            }
        }
    }
}

