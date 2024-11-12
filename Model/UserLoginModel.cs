using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Coloque Email")]
        [EmailAddress(ErrorMessage = "Coloque Email")]
        public string Username { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Coloque Senha")]
        //[RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
