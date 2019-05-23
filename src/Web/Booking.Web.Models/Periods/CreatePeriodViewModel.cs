namespace Booking.Web.Models.Periods
{
    using System;

    public class CreatePeriodViewModel
    {
        public int RoomId { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
