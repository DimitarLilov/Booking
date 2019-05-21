namespace Booking.Web.Models.Periods
{
    using System;
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class PeriodViewModel : IMapFrom<Period>
    {
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
