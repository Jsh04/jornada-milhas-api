using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Util;

namespace JornadaMilhas.Core.Entities.Depoiments;

public class DepoimentBuilder : Builder<Depoiment, DepoimentBuilder>
{
    protected string _name;
    protected string _depoimentDescription;
    protected byte[] _picture;
    protected long _userId;


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
