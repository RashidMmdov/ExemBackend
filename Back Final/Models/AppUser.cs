using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Final.Models
{
    public class AppUser:IdentityUser
    {
        [Required ,StringLength(15)]
        public string FirstName { get; set; }
        [Required, StringLength(25)]

        public string LastName { get; set; }

    }
}
