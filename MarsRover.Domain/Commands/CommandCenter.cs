using MarsRover.Domain.Commands;
using MarsRover.Domain.Enum;
using MarsRover.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain.Commands
{
    public class CommandCenter : ICommandCenter
    {
        private readonly IRover _rover;
        private readonly ISurface _surface;
        private bool _invalidCommandFound;

        /// <summary>
        /// Creates a new instance of <see cref="CommandCenter"/> with the given <see cref="IRover"/> and <see cref="ISurface"/>.
        /// </summary>
        public CommandCenter(IRover rover, ISurface surface)
        {
            _rover = rover;
            _surface = surface;
            CheckIfRoverIsInsideSurface();
        }

        public void ExecuteCommands(string commands)
        {
            foreach (char c in commands)
            {
                ProcessCommand(c);
            }
        }

        private void ProcessCommand(char command)
        {

            if (CommandFactory.TryGetCommand(command, out IMoveCommand moveCommand))
            {
                _rover.Move(moveCommand);
                CheckIfRoverIsInsideSurface();
            }
            else
                _invalidCommandFound = true;
        }

        private void CheckIfRoverIsInsideSurface()
        {
            if (!_surface.IsPointInside(_rover.CurrentPosition))
                _invalidCommandFound = true;
        }

        public string GetStatus()
        {
            return ($"{_rover.CurrentPosition.X},{_rover.CurrentPosition.Y},{GetaDirection(_rover.CurrentPosition.Orientation)}");
        }
        private string GetaDirection(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.N:
                    return "North";
                case DirectionEnum.E:
                    return "East";
                case DirectionEnum.S:
                    return "South";
                case DirectionEnum.W:
                    return "West";
                default:
                    return null;
            }
        }
    }
}
