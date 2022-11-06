using MarsRover.Domain.Enum;
using MarsRover.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain.Concrete
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionEnum Orientation { get; set; }

        /// <summary>
        /// Creates a new <see cref="Position"/> with the given X and Y coordinates and <see cref="DirectionEnum.Orientation"/>.
        /// </summary>        
        public Position(int x, int y, DirectionEnum orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
    }
}
