namespace Booking.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Booking.Data.Common.Models;

    public class Reservation : BaseModel<int>
    {
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public BookingUser User { get; set; }

        [Required]
        [ForeignKey("Room")]
        public int RoomId { get; set; }

        [Required]
        public Room Room { get; set; }

        public DateTime ReservationDate { get; set; }
    }
}
