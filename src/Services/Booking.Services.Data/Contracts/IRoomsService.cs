using Booking.Web.Models.Hotels;
using Booking.Web.Models.Rooms;

namespace Booking.Services.Data.Contracts
{
    public interface IRoomsService
    {
        RoomIdAndNameViewModel GetRoomByRoomId(int id);
    }
}
