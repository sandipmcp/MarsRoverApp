
using MarsRover.Domain.Commands;
using MarsRover.Domain.Concrete;
using MarsRover.Domain.Enum;
using MarsRover.Domain.Interface;
using MarsRover.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MarsRoverApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        private readonly IPositionInputValidator _ipositionInputValidator;

        public RoverController(IPositionInputValidator ipositionInputValidator)
        {
            _ipositionInputValidator = ipositionInputValidator;

        }
        [HttpPost]
        public async Task<IActionResult> SendCommand(RoverModel roverModel)
        {
            BaseOutputModel baseOutputModel = null;
            string errMessage = ValidateInputs(roverModel);
            if (string.IsNullOrEmpty(errMessage))
            {

                ISurface surface = new Surface(roverModel.PlateauModel.Width, roverModel.PlateauModel.Height);
                DirectionEnum orientation = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), roverModel.Direction.ToString());
                IRover rover = new Rover(new Position(roverModel.CoordinateModel.XCoord, roverModel.CoordinateModel.YCoord, orientation));
                ICommandCenter command = new CommandCenter(rover,surface);
                command.ExecuteCommands(roverModel.MessageCommand);
                string result = command.GetStatus();
                baseOutputModel = new BaseOutputModel() { Error = errMessage,Result= result,Success=true };
            }
            else
            {
                baseOutputModel = new BaseOutputModel() { Error = errMessage };
            }
            return Ok(baseOutputModel);
        }
        private string ValidateInputs(RoverModel roverModel)
        {
            return _ipositionInputValidator.ValidateInputs(roverModel);
        }
    }
}
