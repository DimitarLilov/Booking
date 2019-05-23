namespace Booking.Web.Models.Periods
{
    using System.Collections.Generic;
    using Booking.Web.Models.Reservations;

    public class PeriodDetailsViewModel
    {
        public PeriodAdminViewModel Period { get; set; }

        public IEnumerable<ReservationDetailsViewModel> Reservations { get; set; }
    }
}
