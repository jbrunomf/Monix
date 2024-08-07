using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monix.Core.Responses
{
    public class PagedResponse<T> : Response<T>
    {
        public PagedResponse(T data, int code, string message = null)
        {
            Data = data;
        }

        public PagedResponse(T? data, int totalCount, int currentPage, int pageSize, int code = Configuration.DefaultStatusCode, string? message = null) : base(data, code, message)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
