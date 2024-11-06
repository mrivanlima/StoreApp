using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class AppSettings
    {
        public int StoreId { get; set; }
        public Guid StoreUniqueId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string AppVersion { get; set; } = string.Empty;
        public DateTime VersionDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
