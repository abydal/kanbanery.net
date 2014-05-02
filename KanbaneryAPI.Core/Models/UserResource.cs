using System;
using Newtonsoft.Json;


namespace KanbaneryAPI.Core.Models
{
    public class UserResource
    {
        [JsonProperty(PropertyName = "id")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "api_token")]
        public string ApiToken { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "gravatar_url")]
        public string GravatarUrl { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
