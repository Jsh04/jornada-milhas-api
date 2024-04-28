using JornadaMilhas.Common;
using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;
using System.Numerics;



namespace JornadaMilhas.Core.Entities.Destinys;

public class DestinyBuilder : Builder<Destiny>
{
    private readonly Destiny _destino;

    protected string Name;

    protected string Subtitle;

    protected double Price;

    protected string DescriptionPortuguese;

    protected string DescriptionEnglish;

    protected List<ImagemDestino> Images = new();
    
    public static DestinyBuilder Create() => new();

    public DestinyBuilder AddName(string name)
    {
        if (string.IsNullOrEmpty(name))
            Result.Fail<Destiny>(DestinyErrors.NameIsRequired);

        Name = name;

        return this;
    }

    public DestinyBuilder AddSubtitle(string subtitle)
    {
        Subtitle = subtitle;
        return this;
    }

    public DestinyBuilder AddPrice(double price)
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

    public DestinyBuilder AddImages(List<string> pictures)
    {
        Images = ReturnListByteArray(pictures);
        return this;
    }

    public override Result<Destiny> Build() 
    {
        var destinyCreated = Destiny
            .Create(Name, 
            Subtitle, 
            Price, 
            DescriptionPortuguese, 
            DescriptionEnglish,
            Images);

        if (!destinyCreated.Success)
            return Result.Fail<Destiny>(destinyCreated.Errors);

        return destinyCreated;

    }

    private static List<ImagemDestino> ReturnListByteArray(List<string> pictures)
    {
        List<ImagemDestino> listImgs = new();

        pictures.ForEach(fileBase64 =>
        {
            listImgs.Add(new ImagemDestino
            {
                ImagemBytes = Convert.FromBase64String(fileBase64)
            });

        });

        return listImgs;
    }



}
