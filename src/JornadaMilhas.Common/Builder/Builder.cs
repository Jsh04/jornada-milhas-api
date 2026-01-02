using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;

namespace JornadaMilhas.Common.Builder;

public abstract class Builder<TEntity, TBuilder> where TEntity : BaseEntity
where TBuilder : Builder<TEntity, TBuilder>
{
    protected readonly List<IError> _errors = new();
    
    public abstract Result<TEntity> Build();
}