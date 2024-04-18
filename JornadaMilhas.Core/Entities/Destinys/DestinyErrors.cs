using JornadaMilhas.Common.Result.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Entities.Destinys
{
    public record DestinyErrors
    {
        public static readonly Error CannotBeCreated = new(500, "Erro ao cadastrar Destino", ErrorType.Failure);

        public static readonly Error NotFound = new(404, "Erro ao encontrar Destino", ErrorType.NotFound);
    }
}
