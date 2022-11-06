using MarsRover.Domain.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MarsRover.Domain.Model
{
    public class RoverModel
    {
        [Required]
        public PlateauModel PlateauModel { get; set; }
        [Required]
        public CoordinateModel CoordinateModel { get; set; }
        [Required]
        public string MessageCommand { get; set; }
        [Required]
        [EnumDataType(typeof(DirectionEnum))]
        [JsonConverter(typeof(StringEnumConverter))]
        public DirectionEnum Direction { get; set; }
    }
}
