using System.ComponentModel.DataAnnotations;


namespace JornadaMilhas.Core.Entities;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }
    public DateTime DtCreated { get; set; }
    public bool IsDeleted { get; set; }
}