namespace Booking.Web.Models.Periods
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Booking.Web.Models.Rooms;

    public class PeriodAdminViewModel
    {
        public RoomViewModel Room { get; set; }

        public int Id { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EndDate { get; set; }
    }
}
