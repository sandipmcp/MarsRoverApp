using MarsRover.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain.Concrete
{
    public class Surface : ISurface
    {
        public int Width { get; private set; }
        public int Length { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="Surface"/> with the given width and length.
        /// </summary>        
        public Surface(int width, int length)
        {
            Width = width;
            Length = length;
        }

        public bool IsPointInside(IPosition pointPosition)
        {
            return pointPosition.X <= Width
                    && pointPosition.Y <= Length
                    && pointPosition.X >= 0
                    && pointPosition.Y >= 0;
        }
    }
}
