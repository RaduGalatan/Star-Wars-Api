using Newtonsoft.Json;
using Star_Wars_Api.Interface;

namespace Star_Wars_Api.Models
{
    public class Vehicle : BaseVehicleModel
    {

        [JsonProperty(PropertyName = "vehicle_class")]
        public string VehicleClass { get; set; }

        public List<string> Pilots { get; set; }

        public List<string> Films { get; set; }
    }
}
