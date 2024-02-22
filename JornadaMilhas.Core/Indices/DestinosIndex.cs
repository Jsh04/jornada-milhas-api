

namespace JornadaMilhas.Core.Indices;

public class DestinosIndex : ElasticBaseIndex
{
    public string Name { get; set; }

    public List<string> Pictures { get; set; }

    public string Subtitle { get; set; }

    public double Price { get; set; }

    public string DescriptionPortuguese { get; set; }

    public string DescriptionEnglish { get; set; }
}
