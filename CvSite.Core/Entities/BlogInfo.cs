using System.Text.Json.Serialization;

namespace CvSite.Core.Entities;

public class BlogInfo
{
    [JsonPropertyName(nameof(BlogInfoId))]
    public int BlogInfoId { get; set; }

    [JsonPropertyName(nameof(Image))]
    public string? Image { get; set; }

    [JsonPropertyName(nameof(Title))]
    public string? Title { get; set; }

    [JsonPropertyName(nameof(Description))]
    public string? Description { get; set; }

    [JsonPropertyName(nameof(MainImage))]
    public string? MainImage { get; set; }

    [JsonPropertyName(nameof(CreateDate))]
    public DateTime? CreateDate { get; set; }

    [JsonPropertyName(nameof(Author))]
    public string? Author { get; set; }
}