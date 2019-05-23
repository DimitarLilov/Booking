namespace Booking.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Booking.Web.Models.Periods;

    public interface IPeriodsService
    {
        IEnumerable<PeriodViewModel> GetPeriodsByRoomId(int id);

        IEnumerable<PeriodViewModel> GetPeriodsByRoomIdFilterByMonthAndYear(int id, int month, int year);

        bool RoomIsAvailable(int roomId, DateTime date);

        decimal GetPriceByPeriod(DateTime date);

        Task CreatePeriodAsync(CreatePeriodBindingModel bindingModel);

        IEnumerable<PeriodAdminViewModel> GetAllPeriods();

        PeriodAdminViewModel GetPeriodById(int id);

        Task EditPeriod(int id, EditPeriodBindingModel bindingModel);
    }
}
