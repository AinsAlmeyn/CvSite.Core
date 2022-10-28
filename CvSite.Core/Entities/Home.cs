using System.Text.Json.Serialization;

namespace CvSite.Core.Entities;

public class Home
{
    [JsonPropertyName(nameof(Id))]
    public int Id { get; set; }

    [JsonPropertyName(nameof(Photo))]
    public string? Photo { get; set; }

    [JsonPropertyName(nameof(Jobs))]
    public string? Jobs { get; set; }

    [JsonPropertyName(nameof(LinkInstagram))]
    public string? LinkInstagram { get; set; }

    [JsonPropertyName(nameof(LinkLinkedin))]
    public string? LinkLinkedin { get; set; }
}