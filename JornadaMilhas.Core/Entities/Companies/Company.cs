using System.Numerics;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Admins;
using Plane = JornadaMilhas.Core.Entities.Planes.Plane;

namespace JornadaMilhas.Core.Entities.Companies;

public class Company : BaseEntity
{
    private Company(string name, string originCountry, DateTime dtFoundation)
    {
        Name = name;
        OriginCountry = originCountry;
        DtFoundation = dtFoundation;
    }

    public string Name { get; private set; }

    public string OriginCountry { get; private set; }

    public DateTime DtFoundation { get; private set; }

    public List<Plane> Planes { get; }
    
    public List<Admin> Admins { get; }

    public static Result<Company> Create(string name, string originCountry, DateTime dtFoundation)
    {
        
        var company = new Company(name, originCountry, dtFoundation);

        return Result.Ok(company);
    }
}