namespace Booking.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Booking.Data.Models;
    using Booking.Web.Models.Reservations;

    public interface IReservationsService
    {
        IEnumerable<ReservaionDateViewModel> GetReservationsByRoomId(int id);

        IEnumerable<ReservaionDateViewModel> GetReservationsByRoomIdFilterByMonthAndYear(int id, int month, int year);

        bool RoomIsReserved(int id, DateTime date);

        Task ReservationRoom(ReservationRoomBindingModel bindingModel, string userId);
    }
}
