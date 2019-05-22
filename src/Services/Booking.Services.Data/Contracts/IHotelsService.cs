namespace Booking.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Booking.Web.Models.Hotels;
    using Booking.Web.Models.Rooms;

    public interface IHotelsService
    {
        IEnumerable<HotelIdAndNameViewModel> GetAll();

        HotelViewModel GetHotelById(int id);

        bool ContainsFloor(int id, int floor);

        HotelFloorRoomsViewModel GetRoomByHotelIdAndFloor(int hotelId, int floor);

        HotelIdAndNameViewModel GetHotelByRoomId(int id);

        IEnumerable<HotelViewModel> GetAllHotelsInfo();

        HotelDetailsViewModel GetHotelDetails(int id);
    }
}
