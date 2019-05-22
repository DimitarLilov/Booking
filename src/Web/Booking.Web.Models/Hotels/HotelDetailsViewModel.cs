namespace Booking.Web.Models.Hotels
{
    using System.Collections.Generic;
    using Booking.Web.Models.Rooms;

    public class HotelDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Floors { get; set; }

        public IEnumerable<RoomViewModel> Rooms { get; set; }
    }
}
