namespace JornadaMilhas.Core.Entities;

public class Destino : BaseEntity
{

    public string Name { get; set; }

    public string Subtitle { get; set; }

    public double Price { get; set; }

    public string DescriptionPortuguese { get; set; }

    public string DescriptionEnglish { get; set; }

    public List<ImagemDestino> Imagens { get; set; }
}
