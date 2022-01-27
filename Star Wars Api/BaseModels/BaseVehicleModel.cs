using Newtonsoft.Json;
using Star_Wars_Api.Models;

namespace Star_Wars_Api.Interface
{

    //base class for vehicles (vehicle and starship)
    public abstract class BaseVehicleModel : BaseModel
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        [JsonProperty(PropertyName = "cost_in_credits")]
        public string CostInCredits { get; set; }

        public string Length { get; set; }

        [JsonProperty(PropertyName = "max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        public string Crew { get; set; }

        public string Passengers { get; set; }

        [JsonProperty(PropertyName = "cargo_capacity")]
        public string CargoCapacity { get; set; }

        public string Consumables { get; set; }
    }
}
