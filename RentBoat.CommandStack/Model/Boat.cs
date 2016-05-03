using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentBoat.CommandStack.Model
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

    }
}
