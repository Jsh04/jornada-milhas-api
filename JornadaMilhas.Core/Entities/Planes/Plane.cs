using JornadaMilhas.Common.Entity;
using JornadaMilhas.Core.Entities.Classes;
using JornadaMilhas.Core.Entities.Companies;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Passages.Enums;

namespace JornadaMilhas.Core.Entities.Planes;

public class Plane : BaseEntity
{
    public string Model { get; }

    public string Manufacturer { get; }

    public string IdentificationCode { get; }

    public bool InOperation { get; }

    public virtual ICollection<Flight> Flights { get; }

    public virtual Company Company { get; }

    public long CompanyId { get; }

    public BusinessClass? BusinessClass { get; }

    public long BusinessClassId { get; private set; }

    public EconomicClass? EconomicClass { get; }
    

    public long EconomicClassId { get; private set; }

    public static Plane Create(PlaneBuilder planeBuilder) => new(planeBuilder);

    private Plane(PlaneBuilder planeBuilder)
    {
        Model = planeBuilder.Model;
        Manufacturer = planeBuilder.Manufacturer;
        IdentificationCode = planeBuilder.IdentificationCode;
        InOperation = planeBuilder.InOperation;
        EconomicClass = planeBuilder.EconomicClass;
        BusinessClass = planeBuilder.BusinessClass;
    }

    private Plane() { }
    
    public Class GetTypeClass(EnumTypeClassPlane typeClass)
    {
        var classesInPlane = GetClassesDictionary();
        
        var classChosen = classesInPlane[typeClass];
        
        if (classChosen is null)
            throw new ApplicationException("Class not exists");
        
        return classChosen;
    }

    private Dictionary<EnumTypeClassPlane, Class> GetClassesDictionary()
    {
        var classes = new Dictionary<EnumTypeClassPlane, Class?>
        {
            { EnumTypeClassPlane.Economic, EconomicClass },
            { EnumTypeClassPlane.Executive, BusinessClass }
        };

        return classes;
    }
}