namespace Booking.Web.Models.Periods
{
    using System;
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class CreatePeriodBindingModel : IMapTo<Period>
    {
        public int RoomId { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
