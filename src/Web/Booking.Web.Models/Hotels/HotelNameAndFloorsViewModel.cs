namespace Booking.Web.Models.Hotels
{
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class HotelNameAndFloorsViewModel : IMapFrom<Hotel>
    {
        public string Name { get; set; }

        public int Floors { get; set; }
    }
}
