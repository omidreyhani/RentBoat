using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentBoat.WebSite.Areas.Customer.Models
{
    public class RegisterNewBoatInputModel
    {
        [Required]
        [DisplayName("Boat Name")]
        public string BoatName { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [DisplayName("Hourly Rate")]
        public decimal HourlyRate  { get; set; }
    }
}