namespace Booking.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Booking.Web.Models.Rooms;

    public interface IRoomsService
    {
        RoomViewModel GetRoomByRoomId(int id);

        Task CreateRoomAsync(int hotelId, CreateRoomBindingModel bindingModel);

        IEnumerable<RoomAdminViewModel> GetAllRooms();

        EditRoomViewModel GetEditRoom(int id);

        Task EditRoom(int id, EditRoomBindingModel bindingModel);

        RoomAdminDetailsViewModel GetRoomDetails(int id);

        RoomPeriodsViewModel GetRoomPeriods(int id);
    }
}
