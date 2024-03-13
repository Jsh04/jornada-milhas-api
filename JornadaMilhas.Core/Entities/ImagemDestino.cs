namespace JornadaMilhas.Core.Entities
{
    public class ImagemDestino : BaseEntity
    {
        public byte[] ImagemBytes{ get; set; }
        public Destino Destino { get; set; }
        public long IdDestino { get; set; }
    }
}