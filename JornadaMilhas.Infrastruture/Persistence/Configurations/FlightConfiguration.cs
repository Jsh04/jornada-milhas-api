using JornadaMilhas.Common.Persistence.Configuration;
using JornadaMilhas.Core.Entities.Flights;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaMilhas.Infrastruture.Persistence.Configurations;

public class FlightConfiguration : BaseEntityConfiguration<Flight>
{
    public override void Configure(EntityTypeBuilder<Flight> builder)
    {
        base.Configure(builder);
    }
}