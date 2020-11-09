using FuelRed.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuelRed.Common.Models
{
   public class PaymentResponse
    {
        public int Id { get; set; }

        
        public DateTime Date { get; set; }

       
        public DateTime DateLocal => Date.ToLocalTime();

       

        public string Amount { get; set; }

      

        public string DocumentNumber { get; set; }


       
        public CurrencyType Currency { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}
