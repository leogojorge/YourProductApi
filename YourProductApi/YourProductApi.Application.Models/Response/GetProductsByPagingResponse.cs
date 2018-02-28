using System;
using System.Collections.Generic;
using System.Text;

namespace YourProductApi.Application.Models.Response
{
    public class GetProductsByPagingResponse
    {
        public long ActualPage { get; set; }
        public long TotalPages { get; set; }
        public string Error { get; set; }
        public IList<GetProductResponse> ProductResponse { get; set; }
    }
}
