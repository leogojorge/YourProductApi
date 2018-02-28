using System;
using System.Collections.Generic;
using System.Text;

namespace YourProductApi.Application.Models.Request
{
    public class SaveProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Code { get; set; }
    }
}
