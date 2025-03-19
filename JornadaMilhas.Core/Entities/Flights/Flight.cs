using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Classes;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.Entities.Passages;
using JornadaMilhas.Core.ValueObjects.Locales;
using Plane = JornadaMilhas.Core.Entities.Planes.Plane;
namespace JornadaMilhas.Core.Entities.Flights;

public class Flight : BaseEntity
{
    private readonly List<Passage> _passages = new();
    
    public DateTime DepartureDate { get; private set; }

    public DateTime LandingDate { get; private set; }

    public decimal BasePrice { get; private set; }

    public string FlightCode { get; private set; }

    public Destination Destiny { get; private set; }

    public Locale Source { get; private set; }

    public bool IsCanceled { get; private set; }

    public Plane Plane { get; private set; }

    public long PlaneId { get; private set; }

    public long DestinationId { get; private set; }

    public IReadOnlyCollection<Passage> Passages => _passages.AsReadOnly();
    
    private Flight(FlightBuilder builder)
    {
        DepartureDate = builder.DepartureDate;
        LandingDate = builder.LandingDate;
        FlightCode = builder.FlightCode;
        Destiny = builder.Destiny;
        Source = builder.Source;
        Plane = builder.Plane;
    }

    private Flight() { }

    public static Flight Create(FlightBuilder builder) => new(builder);
    
    public Result BuyPassageInFlight(Passage passage)
    {
        if (IsCanceled)
            return Result.Fail(FlightErrors.FlightIsCancelled);
        
        var @class = Plane.GetTypeClass(passage.EnumTypeClass);

        if (!@class.SeatAvailable(1))
            return Result.Fail(FlightErrors.FlightAlreadyFull);

        @class.OccupedSeat(1);

        var priceTotalPassage = @class.CalculatePrice(1) + BasePrice;
        
        passage.SetPricePassage(priceTotalPassage);
        
        _passages.Add(passage);

        return Result.Ok();
    }

    public void CancelFlight()
    {
        IsCanceled = true;
    }
}