namespace Booking.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
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

        public async Task CreatePeriodAsync(CreatePeriodBindingModel bindingModel)
        {
            var period = Mapper.Map<Period>(bindingModel);
            await this.periodsRepository.AddAsync(period);
            await this.periodsRepository.SaveChangesAsync();
        }

        public IEnumerable<PeriodViewModel> GetPeriodsByRoomId(int id)
        {
            return this.GetByRoomId(id).To<PeriodViewModel>().ToList();
        }

        public IEnumerable<PeriodViewModel> GetPeriodsByRoomIdFilterByMonthAndYear(int id, int month, int year)
        {
            return this.GetByRoomId(id)
                .Where(p => (p.StartDate.Year == year && p.StartDate.Month == month) ||
                            (p.EndDate.Year == year && p.EndDate.Month == month))
                .To<PeriodViewModel>().ToList();
        }

        public decimal GetPriceByPeriod(DateTime date)
        {
            return this.GetPeriodsInfo().FirstOrDefault(p => date.Date >= p.StartDate.Date && date.Date <= p.EndDate.Date).Price;
        }

        public bool RoomIsAvailable(int roomId, DateTime date)
        {
            return this.GetByRoomId(roomId).Any(p => date.Date >= p.StartDate.Date && date.Date <= p.EndDate.Date);
        }

        private IQueryable<Period> GetByRoomId(int roomId)
        {
            return this.GetPeriodsInfo(p => p.RoomId == roomId);
        }

        private IQueryable<Period> GetPeriodsInfo(
            Expression<Func<Period, bool>> predicate = null,
            Expression<Func<Period, object>> orderBySelector = null,
            int? skip = null,
            int? take = null)
        {
            IQueryable<Period> songsQuery = this.periodsRepository.All();
            if (predicate != null)
            {
                songsQuery = songsQuery.Where(predicate);
            }

            if (orderBySelector != null)
            {
                songsQuery = songsQuery.OrderBy(orderBySelector);
            }

            if (skip != null)
            {
                songsQuery = songsQuery.Skip(skip.Value);
            }

            if (take != null)
            {
                songsQuery = songsQuery.Take(take.Value);
            }

            return songsQuery;
        }
    }
}
