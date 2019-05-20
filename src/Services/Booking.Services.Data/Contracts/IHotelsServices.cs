namespace Booking.Services.Data.Contracts
{
    using System.Collections.Generic;
    using Booking.Web.Models.Hotels;

    public interface IHotelsServices
    {
        IEnumerable<HotelIdAndNameViewModel> GetAll();

        HotelViewModel GetHotelById(int id);

        bool ContainsFloor(int id, int floor);

        HotelFloorRoomsViewModel GetRoomByHotelIdAndFloor(int hotelId, int floor);
    }
}
