namespace Booking.Web.Models.Rooms
{
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class CreateRoomBindingModel : IMapTo<Room>
    {
        public string Name { get; set; }

        public int Floor { get; set; }

        public int HotelId { get; set; }
    }
}
