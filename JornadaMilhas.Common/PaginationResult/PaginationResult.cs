using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.PaginationResult;

public class PaginationResult<T>
{
    public int Page { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public int TotalPages { get; private set; }
    public IReadOnlyList<T> Data { get; private set; } = new List<T>();

    public PaginationResult(int page, int pageSize, int totalCount)
    {
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public PaginationResult(int page, int pageSize, int totalCount, int totalPages, List<T> data)
    {
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = totalPages;
        Data = data;
    }

    public void SetData(IEnumerable<T> data) => Data = data;
    public void SetTotalPages(int totalPages) => TotalPages = totalPages;
    
}
