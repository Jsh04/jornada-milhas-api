using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace JornadaMilhas.Common.Entity;

public abstract class BaseEntity
{
    [Key]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("dtCreated")]
    public DateTime DtCreated { get; protected set; }

    public DateTime DtUpdated { get; protected set; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; protected set; }

    public virtual void Desactive() => IsDeleted = true;
}