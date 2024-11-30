using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Core.Entities.Destinies;

public class DestinyBuilder : Builder<Destiny, DestinyBuilder>
{
    private readonly Destiny _destino;

    protected List<Picture> Images = new();

    private string Name;

    private decimal Price;

    private string Subtitle;

    public static DestinyBuilder Create()
    {
        return new DestinyBuilder();
    }

    public DestinyBuilder AddName(string name)
    {
        Name = name;
        return this;
    }

    public DestinyBuilder AddSubtitle(string subtitle)
    {
        Subtitle = subtitle;
        return this;
    }

    public DestinyBuilder AddPrice(decimal price)
    {
        Price = price;
        return this;
    }

    public DestinyBuilder AddDescriptionPortuguese(string descriptionPortuguese)
    {
        DescriptionPortuguese = descriptionPortuguese;
        return this;
    }

    public DestinyBuilder AddDescriptionEnglish(string descriptionEnglish)
    {
        DescriptionEnglish = descriptionEnglish;
        return this;
    }

    public override Result<Destiny> Build()
    {
        if (_errors.Count > 0)
            return Result.Fail<Destiny>(_errors);

        var destinyCreated = Destiny
            .Create(Name, Subtitle, Price, DescriptionPortuguese, DescriptionEnglish);

        return destinyCreated;
    }
}