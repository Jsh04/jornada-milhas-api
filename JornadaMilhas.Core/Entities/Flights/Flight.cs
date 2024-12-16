using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Passages;
using JornadaMilhas.Core.ValueObjects.Locales;
using Plane = JornadaMilhas.Core.Entities.Planes.Plane;
namespace JornadaMilhas.Core.Entities.Flights;

public class Flight : BaseEntity
{
    private readonly List<Passage> _passages = new();

    private readonly List<Picture> _pictures = new();
    
    public DateTime DepartureDate { get; }

    public DateTime LandingDate { get; }

    public decimal BasePrice { get; }

    public string FlightCode { get; }

    public Locale Destiny { get; }

    public Locale Source { get; }

    public bool IsCanceled { get; private set; }

    public Plane Plane { get; }
    
    public IReadOnlyCollection<Passage> Passages => _passages.AsReadOnly();
    
    public IReadOnlyCollection<Picture> Pictures => _pictures.AsReadOnly();
    
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
        if (_passages.Count >= Plane.TotalSeats)
            return Result.Fail(FlightErrors.FlightAlreadyFull);

        _passages.Add(passage);

        return Result.Ok();
    }

    public int GetTotalYetAvailable () => Plane.TotalSeats - _passages.Count;
    
    public void CancelFlight()
    {
        IsCanceled = true;
    }

    public void AddImagesLocaleDestiny(ICollection<Picture> pictures)
    {
        if (!pictures.Any())
            throw new ArgumentException(null, nameof(pictures));
        
        _pictures.AddRange(pictures);
    }
}