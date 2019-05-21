namespace Booking.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Booking.Data.Common.Repositories;
    using Booking.Data.Models;
    using Booking.Services.Data.Contracts;
    using Booking.Services.Mapping;
    using Booking.Web.Models.Reservations;

    public class ReservationsService : IReservationsService
    {
        private readonly IRepository<Reservation> reservationsRepository;

        public ReservationsService(IRepository<Reservation> reservationsRepository)
        {
            this.reservationsRepository = reservationsRepository;
        }

        public IEnumerable<ReservaionDateViewModel> GetReservationByRoomId(int id)
        {
            return this.reservationsRepository.All().Where(r => r.RoomId == id).To<ReservaionDateViewModel>().ToList();
        }
    }
}
