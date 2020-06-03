using FuelRed.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Models
{
    [NotMapped]
    public class UserViewModel
    {
        public string UserID { get; set; }
        public string Name { get; set; }
       

        public UserType UserType { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Station { get; set; }

        public List<RoleViewModel> Roles { get; set; }

        public RoleViewModel Role { get; set; }
    }
}
