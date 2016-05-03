using System;
using System.ComponentModel.DataAnnotations;

namespace RentBoat.CommandStack.Model
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Boat Boat { get; set; }
    }
}
