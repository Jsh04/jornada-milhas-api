using JornadaMilhas.Core.Entities.Destinys;

namespace JornadaMilhas.Core.Entities;

public class ImagemDestino : BaseEntity
{
    public byte[] ImagemBytes{ get; set; }
    public Destiny Destino { get; set; }
    public long IdDestino { get; set; }
}
