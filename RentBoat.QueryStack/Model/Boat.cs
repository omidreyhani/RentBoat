using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentBoat.QueryStack.Model
{
    public class Boat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BoatName { get; set; }
        [Required]
        public decimal HourlyRate { get; set; }

        public ICollection<Rent> Rents { get; set; }
        public string CustomerName { get; set; }
    }
}
