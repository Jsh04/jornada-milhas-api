using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.PaginationResult;

public static class PaginationResultExtension
{
    public static async Task<PaginationResult<T>> ToPaginationResultAsync<T>(
        this IQueryable<T> query, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var totalCount = await query.CountAsync(cancellationToken);

        var paginatioResult = new PaginationResult<T>(page, pageSize, totalCount);

        var pageCount = (double) totalCount / pageSize;

        var totalPages = (int) Math.Ceiling(pageCount);

        paginatioResult.SetTotalPages(totalPages);

        var skip = (page - 1) * pageSize;

        var data = await query.Skip(skip).Take(pageSize).ToListAsync(cancellationToken);

        paginatioResult.SetData(data);

        return paginatioResult;
    }
}
