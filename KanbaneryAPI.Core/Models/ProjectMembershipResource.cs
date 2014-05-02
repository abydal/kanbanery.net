﻿using System;
using Newtonsoft.Json;

namespace KanbaneryAPI.Core.Models
{
    public class ProjectMembershipResource
    {
        [JsonProperty(PropertyName = "id")]
        public int ProjectMembershipId { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; set; }

        [JsonProperty(PropertyName = "project_id")]
        public int ProjectId { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
