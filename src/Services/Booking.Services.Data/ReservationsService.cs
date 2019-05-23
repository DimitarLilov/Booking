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
            return this.GetByRoomId(id).To<ReservaionDateViewModel>().ToList();
        }

        public IEnumerable<ReservaionDateViewModel> GetReservationsByRoomIdFilterByMonthAndYear(int id, int month, int year)
        {
            return this.GetByRoomId(id)
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
            return this.GetByRoomId(roomId).Any(r => r.ReservationDate.Date == date.Date);
        }

        private IQueryable<Reservation> GetByRoomId(int roomId)
        {
            return this.GetReservationsInfo(r => r.RoomId == roomId);
        }

        private IQueryable<Reservation> GetReservationsInfo(
            Expression<Func<Reservation, bool>> predicate = null,
            Expression<Func<Reservation, object>> orderBySelector = null,
            int? skip = null,
            int? take = null)
        {
            IQueryable<Reservation> songsQuery = this.reservationsRepository.All();
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
