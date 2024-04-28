using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Users;


namespace JornadaMilhas.Core.Entities;

public class Depoimento : BaseEntity
{
    public string Nome { get; set; }
    public string DescricaoDepoimento { get; set; }
    public byte[] Foto { get; set; }
    public User User { get; set; }
    public long IdUsuario { get; set; }
}

