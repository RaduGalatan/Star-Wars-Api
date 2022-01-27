using Newtonsoft.Json;

namespace Star_Wars_Api.Models
{
    public class Film : BaseModel
    {
        public string Title { get; set; }

        [JsonProperty(PropertyName = "episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }

        public List<string> Characters { get; set; }

        public List<string> Planets { get; set; }

        public List<string> Starships { get; set; }

        public List<string> Vehicles { get; set; }

        public List<string> Species { get; set; }
    }
}
