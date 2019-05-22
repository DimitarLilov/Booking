namespace Booking.Web.Models.Reservations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class ReservationRoomBindingModel : IMapTo<Reservation>
    {
        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }
    }
}
