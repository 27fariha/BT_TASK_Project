using System;
using System.Collections.Generic;

namespace Imventory_API.Models.DatabaseMappings
{
    public partial class U01Item
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public long Quantity { get; set; }
        public string Category { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int Status { get; set; }
    }
}
