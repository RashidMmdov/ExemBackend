using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Final.ViewModels
{
    public class LoginVM
    {
        [Required ,StringLength(15)]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]

        public string Password { get; set; }

    }
}
