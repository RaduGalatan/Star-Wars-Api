using Newtonsoft.Json;

namespace Star_Wars_Api.Models
{
    public class Species : BaseModel
    {
        public string Name { get; set; }

        public string Classification { get; set; }

        public string Designation { get; set; }


        [JsonProperty(PropertyName = "average_height")]
        public string AverageHeight { get; set; }


        [JsonProperty(PropertyName = "skin_colors")]
        public string SkinColors { get; set; }


        [JsonProperty(PropertyName = "hair_colors")]
        public string HairColors { get; set; }


        [JsonProperty(PropertyName = "eye_colors")]
        public string EyeColors { get; set; }


        [JsonProperty(PropertyName = "average_lifespan")]
        public string AverageLifespan { get; set; }

        public string Homeworld { get; set; }

        public string Language { get; set; }

        public List<string> People { get; set; }

        public List<string> Films { get; set; }

    }
}
