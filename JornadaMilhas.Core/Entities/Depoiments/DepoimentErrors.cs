using JornadaMilhas.Common.Results.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Entities.Depoiments;

public  record DepoimentErrors
{
    public static readonly Error CannotBeCreated = new("Depoiment.CannotBeCreated", "Erro ao cadastrar Depoimento", ErrorType.Failure);

    public static readonly Error NotFound = new("Depoiment.NotFound", "Depoimento não encontrado", ErrorType.NotFound);

    public static readonly Error CannotConvertStringInByteArray = new("Depoiment.CannotConvertStringInByteArray", "Não pode converter o base 64 em bytes", ErrorType.Failure);

    public static readonly Error CannotBeUpdate = new("Depoiment.CannotUpdate", "Erro ao atualizar Depoimento", ErrorType.Failure);

}
