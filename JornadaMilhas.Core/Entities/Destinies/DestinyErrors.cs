using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Core.Entities.Destinies;

public static class DestinyErrors
{
    public static readonly Error CannotBeCreated =
        new("Destiny.CannotBeCreated", "Erro ao cadastrar Destino", ErrorType.Failure);

    public static readonly Error NotFound = new("Destiny.NotFound", "Erro ao encontrar Destino", ErrorType.NotFound);

    public static readonly Error CannotBeDeleted =
        new("Destiny.NotBeDeleted", "Erro ao deletar Destino", ErrorType.Failure);

    public static readonly Error MustHavePictures =
        new("Destiny.MustHavePictures", "Destino deverá ter imagens", ErrorType.Validation);
}