using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;


namespace JornadaMilhas.Common.Builder;

public abstract class Builder<TEntity> where TEntity : BaseEntity
{
    protected readonly List<IError> _errors = new();

    public abstract Result<TEntity> Build();
}
