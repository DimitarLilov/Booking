namespace Booking.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Booking.Data.Common.Models;

    public class Room : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Floor { get; set; }
        
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
