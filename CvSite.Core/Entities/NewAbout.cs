using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CvSite.Core.Entities
{
    public class NewAbout
    {

        [JsonPropertyName(nameof(NewId))]
        public int NewId { get; set; }

        [JsonPropertyName(nameof(Photo))]
        public string? Photo { get; set; }

        [JsonPropertyName(nameof(Title))]
        public string? Title { get; set; }

        [JsonPropertyName(nameof(Description))]
        public string? Description { get; set; }
    }
}
