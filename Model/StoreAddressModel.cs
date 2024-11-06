using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class StoreAddressModel
    {
        public int StoreAddressId { get; set; }
        public int StoreId { get; set; }
        public int? StreetId { get; set; }
        public string Complement { get; set; } = string.Empty;
        public string ComplementAscii { get; set; } = string.Empty;
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}
