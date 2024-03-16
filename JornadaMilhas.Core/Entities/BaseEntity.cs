using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace JornadaMilhas.Core.Entities;

public class BaseEntity
{
    [Key]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("dtCreated")]
    public DateTime DtCreated { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; set; }
}