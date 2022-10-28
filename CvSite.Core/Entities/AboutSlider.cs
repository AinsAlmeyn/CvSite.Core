using System.Text.Json.Serialization;

namespace CvSite.Core.Entities;

public class AboutSlider
{
    [JsonPropertyName(nameof(SliderId))]
    public int SliderId { get; set; }

    [JsonPropertyName(nameof(SliderIcon))]
    public string? SliderIcon { get; set; }

    [JsonPropertyName(nameof(SliderTitle))]
    public string? SliderTitle { get; set; }

    [JsonPropertyName(nameof(SliderShortDescription))]
    public string? SliderShortDescription { get; set; }
}