namespace Booking.Web.Models.Hotels
{
    using System.Collections.Generic;
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;
    using Booking.Web.Models.Rooms;

    public class HotelFloorRoomsViewModel : IMapFrom<Hotel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public IEnumerable<RoomViewModel> Rooms { get; set; }
    }
}
