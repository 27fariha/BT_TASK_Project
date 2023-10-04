using System;
using System.Collections.Generic;

namespace Imventory_API.Models.DatabaseMappings
{
    public partial class U01Ser
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastLoginTimestamp { get; set; }
        public int Status { get; set; }
        public long? AddedBy { get; set; }
        public string username { get; set; }
    }
}
