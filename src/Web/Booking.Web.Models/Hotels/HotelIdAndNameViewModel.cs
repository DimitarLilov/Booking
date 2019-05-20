namespace Booking.Web.Models.Hotels
{
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class HotelIdAndNameViewModel : IMapFrom<Hotel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
