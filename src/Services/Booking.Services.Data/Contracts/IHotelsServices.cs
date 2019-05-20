namespace Booking.Services.Data.Contracts
{
    using System.Collections.Generic;
    using Booking.Web.Models.Hotels;

    public interface IHotelsServices
    {
        IEnumerable<HotelIdAndNameViewModel> GetAll();

        HotelNameAndFloorsViewModel GetHotelById(int id);
    }
}
