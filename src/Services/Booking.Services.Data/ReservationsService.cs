namespace Booking.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
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

        public IEnumerable<ReservaionDateViewModel> GetReservationsByRoomId(int id)
        {
            return this.reservationsRepository.All().Where(r => r.RoomId == id).To<ReservaionDateViewModel>().ToList();
        }

        public IEnumerable<ReservaionDateViewModel> GetReservationsByRoomIdFilterByMonthAndYear(int id, int month, int year)
        {
            return this.reservationsRepository.All()
                .Where(r => r.RoomId == id)
                .Where(r => r.ReservationDate.Month == month && r.ReservationDate.Year == year)
                .To<ReservaionDateViewModel>().ToList();
        }

        public async Task ReservationRoom(ReservationRoomBindingModel bindingModel, string userId)
        {
            var reservation = Mapper.Map<Reservation>(bindingModel);
            reservation.UserId = userId;
            await this.reservationsRepository.AddAsync(reservation);
            await this.reservationsRepository.SaveChangesAsync();
        }

        public bool RoomIsReserved(int roomId, DateTime date)
        {
            return this.reservationsRepository.All().Where(r => r.RoomId == roomId).Any(r => r.ReservationDate.Date == date.Date);
        }
    }
}
