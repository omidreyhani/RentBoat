using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RentBoat.WebSite.Areas.Customer.Models
{
    public class ReturnBoatViewModel
    {
        [DisplayName("Rent Time")]
        public TimeSpan RentTime { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }
    }
}