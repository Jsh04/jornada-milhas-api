using System.Text.Json.Serialization;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Core.Entities.Destinies;

public class Destiny : BaseEntity
{
    private readonly List<Picture> _pictures;
    
    [JsonPropertyName("name")]
    public string Name { get;}

    [JsonPropertyName("subtitle")]
    public string Subtitle { get; }
    
    [JsonPropertyName("descriptionPortuguese")]
    public string DescriptionPortuguese { get; }

    [JsonPropertyName("descriptionEnglish")]
    public string DescriptionEnglish { get;}
    
    [JsonPropertyName("imagens")]
    public IReadOnlyCollection<Picture> Pictures => _pictures.AsReadOnly();
    

    private Destiny(string name, string subtitle, string descriptionPortuguese, string descriptionEnglish)
    {
        Name = name;
        Subtitle = subtitle;
        DescriptionPortuguese = descriptionPortuguese;
        DescriptionEnglish = descriptionEnglish;
        _pictures = new List<Picture>();
    }

    public void AddImageDestiny(Picture picture)
    {
        _pictures.Add(picture);
    }
    
    public void AddImagesDestiny(IEnumerable<Picture> pictures)
    {
        _pictures.AddRange(pictures);
    }

    public static DestinyBuilder CreateBuilder() => DestinyBuilder.Create();

    public static Result<Destiny> Create(string name, string subtitle, decimal price, string descriptionPortuguese, string descriptionEnglish)
    {
        var destiny = new Destiny(name, subtitle, descriptionPortuguese, descriptionEnglish);

        return Result<Destiny>.Ok(destiny);
    }

}



