namespace Booking.Web.Models.Rooms
{
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class EditRoomBindingModel : IMapTo<Room>
    {
        public string Name { get; set; }
    }
}
