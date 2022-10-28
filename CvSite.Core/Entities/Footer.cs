using System.Text.Json.Serialization;

namespace CvSite.Core.Entities;

public class Footer
{
    [JsonPropertyName(nameof(Id))]
    public int Id { get; set; }

    [JsonPropertyName(nameof(Instagram))]
    public string? Instagram { get; set; }
    
    [JsonPropertyName(nameof(Linkedin))]
    public string? Linkedin { get; set; }
}