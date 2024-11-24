using JornadaMilhas.Common.Entity;

namespace JornadaMilhas.Common.DTO;

public static class DtoExtensions<TEntity, TDto> where TEntity : BaseEntity
{
    public static TDto ToDto(TEntity entity)
    {
        var dto = Activator.CreateInstance<TDto>();

        var typeEntity = entity.GetType();

        foreach (var propEntity in typeEntity.GetProperties())
        {
            var propDto = dto?.GetType().GetProperty(propEntity.Name);

            propDto?.SetValue(dto, propEntity.GetValue(entity));
        }

        return dto;
    }

    public static IEnumerable<TDto> ToDto(IEnumerable<TEntity> objs)
    {
        return objs is not null ? objs.Select(obj => ToDto(obj)) : Enumerable.Empty<TDto>();
    }
}