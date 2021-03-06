﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FuelRed.Web.Data.Entities
{
    public class StationEntity
    {

        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Required(ErrorMessage = "The {0} field is mandatory ")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Required(ErrorMessage = "The {0} field is mandatory ")]
        public string Address { get; set; }


        [Display(Name = "Legal Certificate")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Required(ErrorMessage = "The {0} field is mandatory ")]
        public string LegalCertificate { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        [Display(Name = "Legal name")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters")]
        [Required(ErrorMessage = "The {0} field is mandatory ")]
        public string LegalName { get; set; }

        public int DispenserNumber => Dispensers == null ? 0 : Dispensers.Count;

        public ICollection<ProductEntity> Products { get; set; }

        public ICollection<EmployeeEntity> Employees { get; set; }

        public ICollection<TransactionEntity> Transactions { get; set; }

        public ICollection<UserEntity> Users { get; set; }

        public ICollection<DispenserEntity> Dispensers { get; set; }

        public ICollection<Truck> Trucks { get; set; }

        public ICollection<Driver> Drivers { get; set; }

    }

}
