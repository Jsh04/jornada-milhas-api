using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Util;

namespace JornadaMilhas.Core.Entities.Depoiments;

public class DepoimentBuilder : Builder<Depoiment, DepoimentBuilder>
{
    private string _depoimentDescription;
    private string _name;
    private byte[] _picture;
    private long _userId;


    public static DepoimentBuilder Create() => new();
    
    public DepoimentBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public DepoimentBuilder WithDepoimentDescription(string depoimentDescription)
    {
        _depoimentDescription = depoimentDescription;
        return this;
    }

    public DepoimentBuilder WithUserId(long userId)
    {
        _userId = userId;
        return this;
    }

    public DepoimentBuilder WithPicture(string picture)
    {
        try
        {
            _picture = JornadaMilhasHelper.ConvertBase64ToByteArray(picture);
        }
        catch (Exception)
        {
            _errors.Add(DepoimentErrors.CannotConvertStringInByteArray);
        }

        return this;
    }


    public override Result<Depoiment> Build()
    {
        if (_errors.Count > 0)
            return Result.Fail<Depoiment>(_errors);

        var depoimentResult = Depoiment.Create(_name, _depoimentDescription, _picture, _userId);

        return depoimentResult;
    }
}