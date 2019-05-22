namespace Booking.Services.Data.Contracts
{
    using Booking.Web.Models.Rooms;

    public interface IRoomsService
    {
        RoomViewModel GetRoomByRoomId(int id);
    }
}
