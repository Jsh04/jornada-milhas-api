using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using System.Text.Json.Serialization;

namespace JornadaMilhas.Core.Entities.Destinys;

public class Destiny : BaseEntity
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("subtitle")]
    public string Subtitle { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("descriptionPortuguese")]
    public string DescriptionPortuguese { get; set; }

    [JsonPropertyName("descriptionEnglish")]
    public string DescriptionEnglish { get; set; }

    [JsonPropertyName("imagens")]
    public List<ImagemDestino> Imagens { get; set; }

    public static DestinyBuilder CreateBuilder() => DestinyBuilder.Create();

    public static Result<Destiny> Create(string name, string subtitle, double price, string descriptionPortuguese, string descriptionEnglish, List<ImagemDestino> imags)
    {
        var destiny = new Destiny
        {
            Name = name,
            Subtitle = subtitle,
            Price = price,
            DescriptionPortuguese = descriptionPortuguese,
            DescriptionEnglish = descriptionEnglish,
            Imagens = imags
        };

        return Result<Destiny>.Ok(destiny);
    }

}



