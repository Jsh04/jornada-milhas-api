using JornadaMilhas.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.DTO;

public static class DtoExtensions<TEntity, TDto> where TEntity : BaseEntity
{
    public static TDto ToDto(TEntity entity)
    {
        var dto = Activator.CreateInstance<TDto>();

        var type = entity.GetType();

        foreach (var item in type.GetProperties())
        {
            var propDto = dto.GetType().GetProperty(item.Name);

            propDto?.SetValue(dto, item.GetValue(entity));
        }

        return dto;
    }

    public static IEnumerable<TDto> ToDto(IEnumerable<TEntity> objs) => objs is not null ? objs.Select(obj => ToDto(obj)) : Enumerable.Empty<TDto>();
}
