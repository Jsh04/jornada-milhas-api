using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities.Classes;

namespace JornadaMilhas.Core.Entities.Planes
{
    public class PlaneBuilder : Builder<Plane, PlaneBuilder>
    {
        public string Model { get; private set; }

        public string Manufacturer { get; private set; }

        public string IdentificationCode { get; private set; }

        public bool InOperation { get; private set; }

        public int TotalSeats { get; private set; }

        public EconomicClass  EconomicClass { get; private set; }

        public static PlaneBuilder Create() => new();
        
        public PlaneBuilder WithEconomicClass(EconomicClass economicClass)
        {
            EconomicClass = economicClass;
            return this;
        }

        public override Result<Plane> Build()
        {
            var plane = Plane.Create(this);
            
            return Result.Ok(plane);
        }
    }
}
