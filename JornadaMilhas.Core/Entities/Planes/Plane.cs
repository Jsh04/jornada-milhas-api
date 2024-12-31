using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Classes;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Passages.Enums;

namespace JornadaMilhas.Core.Entities.Planes;

public class Plane : BaseEntity
{
    private Plane(PlaneBuilder planeBuilder)
    {
        Model = model;
        Manufacturer = manufacturer;
        IdentificationCode = identificationCode;
        InOperation = inOperation;
    }


    public string Model { get; }

    public string Manufacturer { get; }

    public string IdentificationCode { get; }

    public bool InOperation { get; }

    public virtual ICollection<Flight> Flights { get; }

    public virtual Company Company { get; }

    public long CompanyId { get; }

    public BusinessClass BusinessClass { get; }

    public EconomicClass EconomicClass { get; }

    public Class GetTypeClass(EnumTypeClassPlane typeClass)
    {
        switch (typeClass)
        {
            case EnumTypeClassPlane.Economic:
                return EconomicClass;
            case EnumTypeClassPlane.Executive:
                return BusinessClass;
            default:
                throw new ArgumentException(null, nameof(typeClass));
        }
    }
}