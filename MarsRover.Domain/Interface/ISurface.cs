using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain.Interface
{
    public interface ISurface
    {
        /// <summary>
        /// The width of the surface.
        /// </summary>
         int Width { get; }

        /// <summary>
        /// The length of the surface.
        /// </summary>
         int Length { get; }

        /// <summary>
        /// Indicates whether the given point is within the boundaries of the surface.
        /// </summary>                

        bool IsPointInside(IPosition pointPosition);

    }
}