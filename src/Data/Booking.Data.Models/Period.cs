namespace Booking.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Booking.Data.Common.Models;

    public class Period : BaseModel<int>
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
