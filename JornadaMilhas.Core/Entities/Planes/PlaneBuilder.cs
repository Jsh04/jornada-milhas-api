using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Entities.Planes
{
    public class PlaneBuilder : Builder<Plane, PlaneBuilder>
    {
        public string Model { get; }

        public string Manufacturer { get; }

        public string IdentificationCode { get; }

        public bool InOperation { get; }

        public int TotalSeats { get; }

        public

        public override Result<Plane> Build()
        {
            throw new NotImplementedException();
        }
    }
}
