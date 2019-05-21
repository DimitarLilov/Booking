using System.Collections.Generic;
using Booking.Web.Models.Reservations;

namespace Booking.Services.Data.Contracts
{
    public interface IReservationsService
    {
        IEnumerable<ReservaionDateViewModel> GetReservationsByRoomId(int id);
        IEnumerable<ReservaionDateViewModel> GetReservationsByRoomIdFilterByMonthAndYear(int id, int month, int year);
    }
}
