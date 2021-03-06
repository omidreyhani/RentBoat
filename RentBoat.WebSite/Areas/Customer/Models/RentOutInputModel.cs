﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentBoat.WebSite.Areas.Customer.Models
{
    public class RentOutInputModel
    {
        [DisplayName("Boat Number")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a correct boat number")]
        public int BoatNumber { get; set; }

        [DisplayName("Customer Name")]
        [Required]
        public string CustomerName { get; set; }
    }
}