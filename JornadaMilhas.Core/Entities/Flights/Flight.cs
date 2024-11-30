using System.Numerics;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.Entities.Passages;

namespace JornadaMilhas.Core.Entities.Flights;

public class Flight : BaseEntity
{
    private readonly List<Passage> _passages;
    public DateTime DepartureDate { get; }

    public DateTime LandingDate { get; }

    public decimal BasePrice { get; }

    public string FlightCode { get; }

    public virtual Destiny Destiny { get; }

    public bool IsCanceled { get; private set; }

    public virtual Plane Plane { get; }
    public int MaxCount { get; }

    public IReadOnlyCollection<Passage> Passages => _passages.AsReadOnly();

    public Result BuyPassageInFlight(Passage passage)
    {
        if (_passages.Count >= MaxCount)
            return Result.Fail(FlightErrors.FlightAlreadyFull);

        _passages.Add(passage);

        return Result.Ok();
    }

    public void CancelFlight()
    {
        IsCanceled = true;
    }
}