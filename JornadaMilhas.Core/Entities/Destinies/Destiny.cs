using System.Text.Json.Serialization;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Core.Entities.Destinies;

public class Destiny : BaseEntity
{
    private readonly List<Picture> _pictures;

    private Destiny(DestinyBuilder builder)
    {
        Name = builder;
        Subtitle = subtitle;
        DescriptionPortuguese = descriptionPortuguese;
        DescriptionEnglish = descriptionEnglish;
        _pictures = new List<Picture>();
    }

    [JsonPropertyName("name")] 
    public string Name { get; init; }

    [JsonPropertyName("subtitle")] 
    public string Subtitle { get; init; }

    [JsonPropertyName("descriptionPortuguese")]
    public string DescriptionPortuguese { get; init; }

    [JsonPropertyName("descriptionEnglish")]
    public string DescriptionEnglish { get; init; }

    [JsonPropertyName("imagens")] public IReadOnlyCollection<Picture> Pictures => _pictures.AsReadOnly();

    public void AddImageDestiny(Picture picture)
    {
        _pictures.Add(picture);
    }

    public void AddImagesDestiny(IEnumerable<Picture> pictures)
    {
        _pictures.AddRange(pictures);
    }

    public static DestinyBuilder CreateBuilder()
    {
        return DestinyBuilder.Create();
    }

    public static Result<Destiny> Create(DestinyBuilder builder)
    {
        var destiny = new Destiny(builder);

        return Result<Destiny>.Ok(destiny);
    }
}