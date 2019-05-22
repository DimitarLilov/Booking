namespace Booking.Web.Models.Rooms
{
    using System.Collections.Generic;
    using Booking.Web.Models.Hotels;
    using Booking.Web.Models.Periods;
    using Booking.Web.Models.Reservations;

    public class RoomDetailsViewModel
    {
        public RoomViewModel Room { get; set; }

        public HotelIdAndNameViewModel Hotel { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public IEnumerable<PeriodViewModel> Periods { get; set; }

        public IEnumerable<ReservaionDateViewModel> Reservations { get; set; }
    }
}
