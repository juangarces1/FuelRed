using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FuelRed.Web.Models
{
    [NotMapped]
    public class RoleViewModel
    {
        public string RoleID { get; set; }

        public string Name { get; set; }

    }
}
