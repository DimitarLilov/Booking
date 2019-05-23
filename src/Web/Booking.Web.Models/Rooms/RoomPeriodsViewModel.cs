namespace Booking.Web.Models.Rooms
{
    using System.Collections.Generic;
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;
    using Booking.Web.Models.Periods;

    public class RoomPeriodsViewModel : IMapFrom<Room>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<PeriodViewModel> Periods { get; set; }
    }
}
