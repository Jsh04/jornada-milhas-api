using JornadaMilhas.Common.Builder;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Entities.Passages
{
    public class PassageBuilder : Builder<Passage, PassageBuilder>
    {
        public static PassageBuilder Create() => new();

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
