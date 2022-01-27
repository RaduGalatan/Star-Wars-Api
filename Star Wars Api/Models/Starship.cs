using Newtonsoft.Json;
using Star_Wars_Api.Interface;

namespace Star_Wars_Api.Models
{
    public class Starship : BaseVehicleModel
    {

        [JsonProperty(PropertyName = "hyperdrive_rating")]
        public string HyperdriveRating { get; set; }

        public string MGLT { get; set; }

        [JsonProperty(PropertyName = "starship_class")]
        public string StarshipClass { get; set; }

        public List<string> Pilots { get; set; }
        public List<string> Films { get; set; }

    }
}
