namespace Booking.Web.Models.Periods
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditPeriodBindingModel
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
