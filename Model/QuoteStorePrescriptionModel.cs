using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class QuoteStorePrescriptionModel
    {
        public int QuoteId { get; set; }
        public int StoreId { get; set; }
        public int PrescriptionId { get; set; }
        public bool IsComplete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
