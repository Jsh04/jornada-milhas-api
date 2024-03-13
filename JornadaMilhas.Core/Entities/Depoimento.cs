

using JornadaMilhas.Core.Entities;


namespace JornadaMilhas.Core.Entities;

public class Depoimento : BaseEntity
{
    public string Nome { get; set; }
    public string DescricaoDepoimento { get; set; }
    public byte[] Foto { get; set; }
    public Usuario Usuario { get; set; }
    public long IdUsuario { get; set; }
}

