using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JornadaMilhas.Core.DTO.Depoimeto;

public class DepoimentoDTO
{
    [Required]
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    [JsonPropertyName("descricao")]
    public string DescricaoDepoimento { get; set; }
    [JsonPropertyName("foto")]
    public string Foto { get; set; }
}
