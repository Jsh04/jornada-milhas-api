using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Core.Entities.Companies;

public static class CompanyErrors
{
    public static IError CompanyAlreadyExistsInDatabase => new Error("CompanyErrors.CompanyAlreadyExistsInDatabase",
        "Compania aérea já existe na nossa base de dados", ErrorType.Conflict);

    public static IError CompanyCannotBeCreated => new Error("CompanyErrors.CompanyCannotBeCreated",
        "Não foi possível criar nossa compania", ErrorType.Failure);
}