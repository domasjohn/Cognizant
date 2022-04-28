using System;
using System.Collections.Generic;

namespace Cognizant.Models
{
    public partial class Warehouse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? YearModel { get; set; }
        public string? Price { get; set; }
        public string? Licensed { get; set; }
        public string? DateAdded { get; set; }
    }
}
