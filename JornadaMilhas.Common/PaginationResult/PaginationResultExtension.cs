using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.PaginationResult;

public static class PaginationResultExtension
{
    public static PaginationResult<T> ToPaginationResult<T>(
        this IQueryable<T> query, int page, int pageSize)
    {
        var totalCount = query.Count();

        var paginatioResult = new PaginationResult<T>(page, pageSize, totalCount);

        var pageCount = (double)totalCount / pageSize;

        var totalPages = (int)Math.Ceiling(pageCount);

        paginatioResult.SetTotalPages(totalPages);

        var skip = (page - 1) * pageSize;

        var data = query.Skip(skip).Take(pageSize).ToList();

        paginatioResult.SetData(data);

        return paginatioResult;
        

        
    }
}
