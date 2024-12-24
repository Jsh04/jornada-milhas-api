using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Entities.Flights;

namespace JornadaMilhas.Core.Entities.Planes;

public class Plane : BaseEntity
{
    public Plane(string model, string manufacturer, string identificationCode, bool inOperation, int totalSeats)
    {
        Model = model;
        Manufacturer = manufacturer;
        IdentificationCode = identificationCode;
        InOperation = inOperation;
        TotalSeats = totalSeats;
    }

    private Plane()
    {
        
    }
    public string Model { get; }

    public string Manufacturer { get; }

    public string IdentificationCode { get; }

    public bool InOperation { get; }

    public int TotalSeats { get; }

    public virtual ICollection<Flight> Flights { get; }

    public virtual Company Company { get; }

    public long CompanyId { get; set; }
}