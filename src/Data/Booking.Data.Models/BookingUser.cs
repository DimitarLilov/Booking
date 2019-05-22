namespace Booking.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class BookingUser : IdentityUser
    {
        public BookingUser()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}