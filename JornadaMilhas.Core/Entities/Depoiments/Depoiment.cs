using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Core.Entities.Depoiments;

public class Depoiment : BaseEntity
{
    public string Name { get; private set; }
    public string DepoimentDescription { get; private set; }
    public byte[] Picture { get; private set; }

    public virtual Customer Customer { get; }
    public long CustomerId { get; private set; }
    
    public static Result<Depoiment> Create(string name, string depoimentDescription, byte[] picture, long userId)
    {
        var depoiment = new Depoiment
        {
            Name = name,
            DepoimentDescription = depoimentDescription,
            Picture = picture,
            CustomerId = userId
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