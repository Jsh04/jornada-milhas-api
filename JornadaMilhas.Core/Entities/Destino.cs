using System.Text.Json.Serialization;

namespace JornadaMilhas.Core.Entities;

public class Destino : BaseEntity
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
}
