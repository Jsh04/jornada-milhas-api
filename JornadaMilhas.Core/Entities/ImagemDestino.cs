using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinies;

namespace JornadaMilhas.Core.Entities;

public class Picture : BaseEntity
{
    public string PathS3 { get;  }
    
    public long DestinyId { get; }
    
    public Destiny Destiny { get; private set; }

    private Picture(string pathS3)
    {
        PathS3 = pathS3;
    }
    
    public static Picture Create(string pathS3) => new(pathS3);
    
}
