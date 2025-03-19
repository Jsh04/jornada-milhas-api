using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhas.Core.Entities;

public class Picture : BaseEntity
{
    private Picture(string pathS3)
    {
        PathS3 = pathS3;
    }

    public string PathS3 { get; init; }

    public long DestinationId { get; init; }

    public Destination Destination { get; private set; }

    public static Picture Create(string pathS3)
    {
        return new Picture(pathS3);
    }
}