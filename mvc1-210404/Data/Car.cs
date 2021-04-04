using System;
using System.Collections.Generic;

#nullable disable

namespace mvc1.Data
{
    public partial class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public DateTime? UpdateWhen { get; set; }
    }
}
