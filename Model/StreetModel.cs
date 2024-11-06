using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class StreetModel
    {
        public int StreetId { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string StreetNameAscii { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public int? NeighborhoodId { get; set; }
    }
}
