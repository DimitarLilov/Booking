namespace Booking.Web.Models.Reservations
{
    using Booking.Web.Models.Rooms;

    public class ReservationAdminViewModel
    {
        public RoomViewModel Room { get; set; }

        public int CountReservation { get; set; }
    }
}
