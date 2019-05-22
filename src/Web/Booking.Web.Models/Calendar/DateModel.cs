namespace Booking.Web.Models.Calendar
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DateModel
    {
        [Required]
        public DateTime Date { get; set; }
    }
}
