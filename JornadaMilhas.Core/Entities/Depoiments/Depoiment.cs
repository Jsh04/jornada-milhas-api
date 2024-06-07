using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users.UserLimited;

namespace JornadaMilhas.Core.Entities.Depoiments;

public class Depoiment : BaseEntity
{
    public string Name { get; private set; }
    public string DepoimentDescription { get; private set; }
    public byte[] Picture { get; private set ; }
    public virtual UserLimited User { get; private set; }
    public long IdUser { get; private set; }

    public static DepoimentBuilder CreateBuilder() => DepoimentBuilder.Create();

    public static Result<Depoiment> Create(string name, string depoimentDescription, byte[] picture, long userId)
    {
        var depoiment = new Depoiment
        {
            Name = name,
            DepoimentDescription = depoimentDescription,
            Picture = picture,
            IdUser = userId
        };
        return Result<Depoiment>.Ok(depoiment);
    }

    public void Update(Depoiment depoiment)
    {
        Name = depoiment.Name;
        DepoimentDescription = depoiment.DepoimentDescription;
        Picture = depoiment.Picture;
    }
}

