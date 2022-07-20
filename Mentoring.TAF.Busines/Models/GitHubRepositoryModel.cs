using Newtonsoft.Json;

namespace Mentoring.TAF.Business.Models
{
    public class GitHubRepositoryModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }
    }
}
