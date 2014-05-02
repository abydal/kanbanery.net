using System;
using Newtonsoft.Json;


namespace KanbaneryAPI.Core.Models
{
    public class TaskType
    {
        [JsonProperty(PropertyName = "id")]
        public int TaskTypeId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }        //name	String	Name

        [JsonProperty(PropertyName = "color_code")]
        public int ColorCode { get; set; }      //color_code	Integer	Color code

        [JsonProperty(PropertyName = "project_id")]
        public int ProjectId { get; set; }      //project_id	Integer	Project to which the task type is assigned

        [JsonProperty(PropertyName = "position")]
        public int Position { get; set; }       //position	Integer	Position in project's task types list, 1-based

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; } //created_at	DateTime	Creation time

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; } //updated_at	DateTime	Last update time

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }        //type	String	Type of this resource, set to "TaskType".
    }
}
