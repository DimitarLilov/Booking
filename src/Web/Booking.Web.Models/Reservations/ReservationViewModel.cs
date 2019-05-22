namespace Booking.Web.Models.Reservations
{
    using System;
    using Booking.Web.Models.Hotels;
    using Booking.Web.Models.Rooms;

    public class ReservationViewModel
    {
        public RoomViewModel Room { get; set; }

        public HotelIdAndNameViewModel Hotel { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }
    }
}
