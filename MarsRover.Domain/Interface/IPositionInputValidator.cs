using MarsRover.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain.Interface
{
    public interface IPositionInputValidator
    {
        string ValidateInputs(RoverModel roverModel);
    }
}