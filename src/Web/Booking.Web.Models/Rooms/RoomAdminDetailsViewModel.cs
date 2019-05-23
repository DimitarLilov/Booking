namespace Booking.Web.Models.Rooms
{
    using AutoMapper;
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;
    using Booking.Web.Models.Periods;
    using Booking.Web.Models.Reservations;
    using System.Collections.Generic;

    public class RoomAdminDetailsViewModel : IMapFrom<Room>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public string HotelName { get; set; }

        public IEnumerable<PeriodViewModel> Periods { get; set; }

        public IEnumerable<ReservaionDateViewModel> Reservations { get; set; }

    }
}
