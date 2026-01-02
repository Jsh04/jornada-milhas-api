using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Core.Entities.Customers;

public static class CustomerErrors
{
    public static IError CustomerUnauthenticated => new Error("CustomerErrors.CustomerUnauthenticated", "Cliente não está autenticado.", ErrorType.Unauthorized);
    public static IError CustomerNotFound => new Error("CustomerErrors.CustomerNotFound", "Cliente não encontrado, por favor, crie uma conta e tente novamente", ErrorType.NotFound);
}