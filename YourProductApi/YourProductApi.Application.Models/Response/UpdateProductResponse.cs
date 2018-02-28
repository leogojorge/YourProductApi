using System;
using System.Collections.Generic;
using System.Text;

namespace YourProductApi.Application.Models.Response
{
    public class UpdateProductResponse
    {
        public string Id { get; set; }
        public IList<string> ErrorMessages { get; set; }
    }
}
