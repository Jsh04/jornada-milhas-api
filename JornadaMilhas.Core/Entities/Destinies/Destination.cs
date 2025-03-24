using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhas.Core.Entities.Destinies;

public class Destination : BaseEntity
{
    public string Title { get; private set; }
    public string Subtitle { get; private set; }
    public Locale Locale { get; private set; }
    public string Description { get; private set; }
    
    private readonly List<Flight> _flights = new();
    
    private readonly List<Picture> _pictures = new();
    
    public IReadOnlyCollection<Picture> Pictures => _pictures.AsReadOnly();
    
    public IReadOnlyCollection<Flight> Flights => _flights.AsReadOnly();

    private Destination(Locale locale, string title, string subtitle, string description)
    {
        Locale = locale;
        Title = title;
        Subtitle = subtitle;
        Description = description;
    }
    
    private Destination(){}
    
    public static Destination Create(string title, string subtitle, Locale locale, string description) => 
        new Destination(locale, title, subtitle, description);
    
    
}