using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Users.UserLimited;

namespace JornadaMilhas.Core.Entities.Passages;

public class Passage : BaseEntity
{
    public UserLimited User { get; set; }

    public int SeatNumber { get; set; }

    public decimal Price { get; set; }

    public Flight Flight { get; set; }
}