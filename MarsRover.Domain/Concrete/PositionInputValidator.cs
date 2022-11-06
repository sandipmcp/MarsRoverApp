using MarsRover.Domain.Common;
using MarsRover.Domain.Interface;
using MarsRover.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain.Service
{
    public class PositionInputValidator : IPositionInputValidator
    {
        public PositionInputValidator()
        {

        }

        public string ValidateInputs(RoverModel roverModel)
        {
            string errorMessage = string.Empty;

            if (string.IsNullOrEmpty(roverModel.Direction.ToString()) || !Validators.ValidateDirection(roverModel.Direction.ToString()))
            {
                errorMessage = Constants.INVALIDROVERDIRECTION;
                return errorMessage;
            }

            if (string.IsNullOrEmpty(roverModel.MessageCommand) || !Validators.ValidateMoveCommand(roverModel.MessageCommand))
            {
                errorMessage = Constants.INVALIDMOVECOMMANDS;
                return errorMessage;
            }

            return errorMessage;
        }
    }
}