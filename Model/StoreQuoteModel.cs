using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class StoreQuoteModel
    {
        public int StoreQuoteId { get; set; }
        public int StoreId { get; set; }
        public int QuoteId { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisualized { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsFinalized { get; set; }
    }
}
