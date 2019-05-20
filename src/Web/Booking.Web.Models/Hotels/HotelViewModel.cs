namespace Booking.Web.Models.Hotels
{
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class HotelViewModel : IMapFrom<Hotel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Floors { get; set; }
    }
}
