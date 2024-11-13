using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class StoreTypeModel
    {
        public byte StoreTypeId { get; set; }

        [Required(ErrorMessage = "Tipo de loja?")]
        public string StoreTypeName { get; set; } = string.Empty;
        public string StoreTypeNameAscii { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
