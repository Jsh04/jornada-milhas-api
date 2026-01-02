using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhas.Core.Entities.Destinies;

public class DestinationBuilder : Builder<Destination, DestinationBuilder>
{
    public string Title { get; private set; }
    
    public string Subtitle { get; private set; }
    
    public Locale Locale { get; private set; }
    
    public string Description { get; private set; }

    public static DestinationBuilder Create() => new();
    
    public DestinationBuilder WithTitle(string title)
    {
        Title = title;
        return this; 
    }

    public DestinationBuilder WithSubtitle(string subtitle)
    {
        Subtitle = subtitle;
        return this;
    }

    public DestinationBuilder WithLocale(string country, string city, string latitude, string longitude)
    {
        var result = Locale.Create(country, city, latitude, longitude);

        if (result.Success)
            Locale = result.Value;
        else
            _errors.AddRange(result.Errors);
        
        return this;
    }

    public DestinationBuilder WithDescription(string description)
    {
        Description = description;
        return this;
    }
    
    
    public override Result<Destination> Build()
    {
        if (_errors.Count > 0)
            return Result.Fail<Destination>(_errors);
        
        var destination = Destination.Create(Title, Subtitle, Locale, Description);
            
        return Result.Ok(destination);
    }
}