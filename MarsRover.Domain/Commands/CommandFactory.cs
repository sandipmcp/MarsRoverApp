using MarsRover.Domain.Interface;

namespace MarsRover.Domain.Commands
{
    /// <summary>
    /// Factory for instantiating new <see cref="IMoveCommand"/>s.
    /// </summary>
    public static class CommandFactory
    {
        private const char RotateRightCommand = 'R';
        private const char RotateLeftCommand = 'L';
        private const char MoveForwardCommand = 'F';

        /// <summary>        
        /// Returns the appropriate <see cref="IMoveCommand"/> based on the passed character.
        /// </summary>
        public static bool TryGetCommand(char command, out IMoveCommand moveCommand)
        {
            switch (char.ToUpper(command))
            {
                case RotateRightCommand:
                    moveCommand = new RotateRightCommand();
                    return true;
                case RotateLeftCommand:
                    moveCommand = new RotateLeftCommand();
                    return true;
                case MoveForwardCommand:
                    moveCommand = new MoveForwardCommand();
                    return true;
                default:
                    moveCommand = null;
                    return false;
            }
        }
    }
}
