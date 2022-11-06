using System;


namespace MarsRover.Domain.Interface
{
    public interface ICommandCenter
    {

        /// <summary>
        /// Executes the given string of commands againts the <see cref="IRover"/>.
        /// </summary>        
        void ExecuteCommands(string commands);

        /// <summary>
        /// Returns the string representation of the current status, position and orientation of the <see cref="IRover"/>.
        /// </summary>        
        string GetStatus();
    }
}
