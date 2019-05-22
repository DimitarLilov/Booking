namespace Booking.Services.Data.Contracts
{
    using System.Threading.Tasks;
    using Booking.Web.Models.Rooms;

    public interface IRoomsService
    {
        RoomViewModel GetRoomByRoomId(int id);

        Task CreateRoomAsync(int hotelId, CreateRoomBindingModel bindingModel);
    }
}
