using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Passages;

namespace JornadaMilhas.Core.Entities.Flights;

public class Flight : BaseEntity
{
    public DateTime DepartureDate { get;  }

    public DateTime LandingDate { get; }
    
    public decimal BasePrice { get;  }

    public string FlightCode { get; }

    public int MaxCount { get; }
    
    private readonly List<Passage> _passages;

    public IReadOnlyCollection<Passage> Passages => _passages.AsReadOnly();

    public Flight()
    {
        _passages = new List<Passage>();
    }

    private Result BuyPassageInFlight(Passage passage)
    {
        if (_passages.Count >= MaxCount)
            return Result.Fail(FlightErrors.FlightAlreadyFull);
        
        _passages.Add(passage);
        
        return Result.Ok();
    }
    
    
    
}