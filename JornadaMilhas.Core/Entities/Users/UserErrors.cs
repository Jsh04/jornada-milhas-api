using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Core.Entities.Users;

public  record UserErrors
{
    public static Error CannotBeCreated => new("User.CannotBeCreated", "Erro ao cadastrar Usuário", ErrorType.Failure);

    public static Error NotFound => new("User.NotFound", "Erro ao encontrar Usuário", ErrorType.NotFound);

    public static Error UserIsNotUnique => new("User.UserIsNotUnique", "Usuário já foi cadastrado", ErrorType.Conflict);

    public static Error UserWithThisEmailNotFound => new("User.UserWithThisEmailNotFound", "Email fornecido não retornou um usuário válido", ErrorType.NotFound);

    public static Error PasswordNotEqual => new("User.PasswordNotEqual", "Senha não coincide", ErrorType.Failure);

    public static Error UserCannotBeDeleted => new("UserErrors.UserCannotBeDeleted", "Usuário não pode ser deletado", ErrorType.Failure);


}
