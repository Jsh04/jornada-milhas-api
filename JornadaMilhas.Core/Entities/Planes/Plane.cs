using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Companies;

namespace JornadaMilhas.Core.Entities.Planes;

public class Plane : BaseEntity
{
    public string Model { get; }
    public string Manufacturer { get; } 
    public string IdentificationCode { get; }
    public bool InOperation { get; }
    
    public virtual Company Company { get; }
    
    public Plane(string model, string manufacturer, string identificationCode, bool inOperation)
    {
        Model = model;
        Manufacturer = manufacturer;
        IdentificationCode = identificationCode;
        InOperation = inOperation;
    }
}

