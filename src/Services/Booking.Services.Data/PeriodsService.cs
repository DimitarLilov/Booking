namespace Booking.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Booking.Data.Common.Repositories;
    using Booking.Data.Models;
    using Booking.Services.Data.Contracts;
    using Booking.Services.Mapping;
    using Booking.Web.Models.Periods;

    public class PeriodsService : IPeriodsService
    {
        private readonly IRepository<Period> periodsRepository;

        public PeriodsService(IRepository<Period> periodsRepository)
        {
            this.periodsRepository = periodsRepository;
        }

        public IEnumerable<PeriodViewModel> GetPeriodsByRoomId(int id)
        {
            return this.periodsRepository.All().Where(p => p.RoomId == id).To<PeriodViewModel>().ToList();
        }

        public IEnumerable<PeriodViewModel> GetPeriodsByRoomIdFilterByMonthAndYear(int id, int month, int year)
        {
            return this.periodsRepository.All()
                .Where(p => p.RoomId == id)
                .Where(p => (p.StartDate.Year == year && p.StartDate.Month == month) || 
                            (p.EndDate.Year == year && p.EndDate.Month == month))
                .To<PeriodViewModel>().ToList();
        }

        public decimal GetPriceByPeriod(DateTime date)
        {
            return this.periodsRepository.All().FirstOrDefault(p => date >= p.StartDate.Date && date.Date <= p.EndDate).Price;
        }

        public bool RoomIsAvailable(int roomId, DateTime date)
        {
            return this.periodsRepository.All()
                .Where(p => p.RoomId == roomId)
                .Any(p => date.Date >= p.StartDate.Date && date.Date <= p.EndDate.Date);
        }
    }
}
