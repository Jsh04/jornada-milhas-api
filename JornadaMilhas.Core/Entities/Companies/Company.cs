using System.Numerics;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Core.Entities.Companies
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; }
        
        public string OriginCountry { get; private set; }

        public DateTime DtFoundation { get; private set; }

        public List<Plane> Planes { get; private set; }


        private Company(string name, string originCountry, DateTime dtFoundation)
        {
            Name = name;
            OriginCountry = originCountry;
            DtFoundation = dtFoundation;
        }

        public static Result<Company> Create(string name, string originCountry, DateTime dtFoundation)
        {
            var company = new Company(name, originCountry, dtFoundation);

            return Result.Ok(company);
        }
    }
}
