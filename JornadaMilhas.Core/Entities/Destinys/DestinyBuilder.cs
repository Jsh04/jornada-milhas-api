using JornadaMilhas.Common.Result;
using JornadaMilhas.Common.Result.Errors;
using System.Numerics;



namespace JornadaMilhas.Core.Entities.Destinys;

public class DestinyBuilder
{
    private readonly Destiny _destino;
    private readonly List<IError> _errors = new();

    public static DestinyBuilder Create() => new();

    protected DestinyBuilder()
    {
        _destino = new Destiny();
    }

    public DestinyBuilder AddName(string name)
    {
        if (!string.IsNullOrEmpty(name))
            _destino.Name = name;
        
        return this;
    }

    public DestinyBuilder AddSubtitle(string subtitle)
    {
        _destino.Subtitle = subtitle;
        return this;
    }

    public DestinyBuilder AddPrice(double price)
    {
        _destino.Price = price;
        return this;
    }

    public DestinyBuilder AddDescriptionPortuguese(string descriptionPortuguese)
    {
        _destino.DescriptionPortuguese = descriptionPortuguese;
        return this;
    }

    public DestinyBuilder AddDescriptionEnglish(string descriptionEnglish)
    {
        _destino.DescriptionEnglish = descriptionEnglish;
        return this;
    }

    public DestinyBuilder AddImages(List<string> pictures)
    {
        _destino.Imagens = ReturnListByteArray(pictures);
        return this;
    }

    public Result<Destiny> Build() 
    {
        if (_errors.Count > 0)
            return Result.Fail<Destiny>(_errors);

        var destinyCreated = Destiny.Create(_destino.Name, _destino.Subtitle, _destino.Price, _destino.DescriptionPortuguese, _destino.DescriptionEnglish, _destino.Imagens);

        if (!destinyCreated.Success)
            return Result.Fail<Destiny>(destinyCreated.Errors);

        return destinyCreated;

    }
        

    private List<ImagemDestino> ReturnListByteArray(List<string> pictures)
    {
        List<ImagemDestino> listImgs = new();

        pictures.ForEach(fileBase64 =>
        {
            listImgs.Add(new ImagemDestino
            {
                ImagemBytes = Convert.FromBase64String(fileBase64),
                Destino = _destino,
                IdDestino = _destino.Id
            });
        });

        return listImgs;
    }
}
