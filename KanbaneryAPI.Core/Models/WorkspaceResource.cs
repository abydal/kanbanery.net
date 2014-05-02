using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KanbaneryAPI.Core.Models
{
    public class WorkspaceResource
    {
        [JsonProperty(PropertyName = "id")]
        public string WorkspaceId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "projects")]
        public List<ProjectResource> Projects{ get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
