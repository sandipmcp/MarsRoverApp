
namespace MarsRover.Domain.Interface
{
    /// <summary>
    /// Represents a movement command that can be executed given an starting position.
    /// </summary>
    public interface IMoveCommand
    {
        /// <summary>
        /// Executes the movement command based on the current <see cref="IPosition"/> and returns the new resulting <see cref="IPosition"/>.
        /// </summary>        
        public IPosition Execute(IPosition currentPosition);
    }
}
