using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain.Interface
{
    public interface IRover
    {
        /// <summary>
        /// The current <see cref="IPosition"/> of the Rover.
        /// </summary>
        public IPosition CurrentPosition { get; }

        /// <summary>
        /// Updates the position of the rover following the execution of the given <see cref="IMoveCommand"/>.
        /// </summary>
        void Move(IMoveCommand moveCommand);

    }
}