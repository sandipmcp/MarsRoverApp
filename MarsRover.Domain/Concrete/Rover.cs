using MarsRover.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain.Concrete
{
    public class Rover : IRover
    {
        public IPosition CurrentPosition { get; private set; }

        /// <summary>
        /// Creates a new instance of the class <see cref="Rover"/> with the given starting <see cref="IPosition"/>.
        /// </summary>        
        public Rover(IPosition startingPosition)
        {
            CurrentPosition = startingPosition;
        }

        public void Move(IMoveCommand moveCommand)
        {
            CurrentPosition = moveCommand.Execute(CurrentPosition);
        }
    }
}