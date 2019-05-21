using System.Collections.Generic;
using Booking.Web.Models.Reservations;

namespace Booking.Services.Data.Contracts
{
    public interface IReservationsService
    {
        IEnumerable<ReservaionDateViewModel> GetReservationByRoomId(int id);
    }
}
