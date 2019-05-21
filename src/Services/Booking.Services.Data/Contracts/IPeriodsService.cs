namespace Booking.Services.Data.Contracts
{
    using System.Collections.Generic;
    using Booking.Web.Models.Periods;

    public interface IPeriodsService
    {
        IEnumerable<PeriodViewModel> GetPeriodsByRoomId(int id);
    }
}
