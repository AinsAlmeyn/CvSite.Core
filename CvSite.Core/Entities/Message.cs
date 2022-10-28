using System.Text.Json;
using System.Text.Json.Serialization;

namespace CvSite.Core.Entities;

public class Message
{
    [JsonPropertyName(nameof(Id))]
    public int Id { get; set; }

    [JsonPropertyName(nameof(Name))]
    public string? Name { get; set; }

    [JsonPropertyName(nameof(Surname))]
    public string? Surname { get; set; }

    [JsonPropertyName(nameof(Subject))]
    public string? Subject { get; set; }

    [JsonPropertyName(nameof(FormMessage))]
    public string? FormMessage { get; set; }
}