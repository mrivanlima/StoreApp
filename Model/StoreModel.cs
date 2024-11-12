using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class StoreModel
    {
        public int StoreId { get; set; }
        public Guid StoreUniqueId { get; set; }

        [Required(ErrorMessage = "CNPJ")]
        public string Cnpj { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nome da Loja")]
        public string StoreName { get; set; } = string.Empty;
        public string StoreNameAscii { get; set; } = string.Empty;
        //public int StoreAddressId { get; set; }
        public bool IsActive { get; set; }
    }
}
