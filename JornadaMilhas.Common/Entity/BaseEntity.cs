using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace JornadaMilhas.Common.Entity;

public abstract class BaseEntity
{
    [Key]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("dtCreated")]
    public DateTime DtCreated { get; set; }

    public DateTime DtUpdated { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; set; }

    public virtual void Desactive() => IsDeleted = true;
}