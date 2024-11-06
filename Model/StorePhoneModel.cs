using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class StorePhoneModel
    {
        public int StorePhoneId { get; set; }
        public int StoreId { get; set; }    

        [Required(ErrorMessage = "Country code is required.")]
        [StringLength(3, ErrorMessage = "Country code cannot exceed 3 characters.")]
        public string CountryCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "State code is required.")]
        [StringLength(3, ErrorMessage = "State code cannot exceed 3 characters.")]
        public string StateCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsMain { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public bool IsWhatsApp { get; set; } = true;
    }
}
