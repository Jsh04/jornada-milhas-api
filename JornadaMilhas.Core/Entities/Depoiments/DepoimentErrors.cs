﻿using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Core.Entities.Depoiments;

public record DepoimentErrors
{
    public static readonly Error CannotBeCreated =
        new("Depoiment.CannotBeCreated", "Erro ao cadastrar Depoimento", ErrorType.Failure);

    public static readonly Error NotFound = new("Depoiment.NotFound", "Depoimento não encontrado", ErrorType.NotFound);

    public static readonly Error CannotConvertStringInByteArray = new("Depoiment.CannotConvertStringInByteArray",
        "Não pode converter o base 64 em bytes", ErrorType.Failure);

    public static readonly Error CannotBeUpdate =
        new("Depoiment.CannotUpdate", "Erro ao atualizar Depoimento", ErrorType.Failure);

    public static readonly Error CannotBeDeleted =
        new("Depoiment.CannotBeDeleted", "Erro ao deletar depoimento", ErrorType.Failure);
}