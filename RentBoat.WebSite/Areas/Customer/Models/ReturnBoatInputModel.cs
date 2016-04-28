using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentBoat.WebSite.Areas.Customer.Models
{
    public class ReturnBoatInputModel
    {
        [DisplayName("Boat Number")]
        [Range(0, int.MaxValue, ErrorMessage = "Please correct boat number")]
        public int BoatNumber { get; set; }
    }
}