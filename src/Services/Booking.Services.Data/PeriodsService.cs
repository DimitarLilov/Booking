namespace Booking.Services.Data
{
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
    }
}
