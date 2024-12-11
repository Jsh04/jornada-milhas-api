using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Passages;
using JornadaMilhas.Core.ValueObjects.Locales;
using Plane = JornadaMilhas.Core.Entities.Planes.Plane;
namespace JornadaMilhas.Core.Entities.Flights;

public class Flight : BaseEntity
{
    private readonly List<Passage> _passages;
    public DateTime DepartureDate { get; }

    public DateTime LandingDate { get; }

    public decimal BasePrice { get; }

    public string FlightCode { get; }

    public Locale Locale { get; }

    public bool IsCanceled { get; private set; }

    public Plane Plane { get; }
    public int MaxCountPassagens { get; }

    public IReadOnlyCollection<Passage> Passages => _passages.AsReadOnly();


    private Flight(FlightBuilder builder)
    {
        
    }
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