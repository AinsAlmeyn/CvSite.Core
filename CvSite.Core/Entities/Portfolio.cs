using System.Text.Json.Serialization;

namespace CvSite.Core.Entities;

public class Portfolio
{

    [JsonPropertyName(nameof(Id))]
    public int Id { get; set; }

    [JsonPropertyName(nameof(Image))]
    public string? Image { get; set; }

    [JsonPropertyName(nameof(Title))]
    public string? Title { get; set; }

    [JsonPropertyName(nameof(Description))]
    public string? Description { get; set; }
}