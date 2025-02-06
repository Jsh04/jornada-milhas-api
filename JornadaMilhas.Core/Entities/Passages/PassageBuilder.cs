using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities.Passages.Enums;

namespace JornadaMilhas.Core.Entities.Passages
{
    public class PassageBuilder : Builder<Passage, PassageBuilder>
    {
        public EnumTypeClassPlane TypeClassPlane { get; private set; }

        public int SeatNumber { get; private set; }
        
        public static PassageBuilder Create() => new();

        public PassageBuilder WithEnumTypePassage(EnumTypeClassPlane enumType)
        {
            TypeClassPlane = enumType;
            return this;
        }
        
        public PassageBuilder WithNumberSeat(int numberSeat)
        {
            SeatNumber = numberSeat;
            return this;
        }
        
        public override Result<Passage> Build()
        {
            if (_errors.Count > 0)
                return Result.Fail<Passage>(_errors);

            var flight = Passage
                .Create(this);
            
            return Result.Ok(flight);
        }
    }
}
