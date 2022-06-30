using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Final.ViewModels
{
    public class RegisterVM
    {
        [Required,StringLength(15)]
        public string FirstName { get; set; }
        [Required, StringLength(25)]

        public string LastName { get; set; }
        [Required, StringLength(15)]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required, DataType(DataType.Password)]

        public string Password { get; set; }
        [Required, DataType(DataType.Password),Compare(nameof(Password))]
        
        public string ConfirmPassword { get; set; }



    }
}
