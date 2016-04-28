using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentBoat.WebSite.Areas.Customer.Models
{
    public class BoatViewModel
    {
        [DisplayName("Boat Number")]
        public int BoatNumber { get; set; }
        [DisplayName("Boat Name")]
        public string BoatName { get; set; }
        [DisplayName("Hourly Rate")]
        public decimal HourlyRate { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
    }
}