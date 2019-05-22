namespace Booking.Web.Models.Rooms
{
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class RoomViewModel : IMapFrom<Room>
    {
        public int Id { get; set; }

        public int Floor { get; set; }

        public string Name { get; set; }
    }
}
