using System.Text.Json.Serialization;

namespace CvSite.Core.Entities;

public class GetInTouch
{
    [JsonPropertyName(nameof(Id))]
    public int Id { get; set; }

    [JsonPropertyName(nameof(District))]
    public string? District { get; set; }

    [JsonPropertyName(nameof(CityCountry))]
    public string? CityCountry { get; set; }

    [JsonPropertyName(nameof(PhoneNumber))]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName(nameof(Email))]
    public string? Email { get; set; }
}