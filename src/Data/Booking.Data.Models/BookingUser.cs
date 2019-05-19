namespace Booking.Data.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class BookingUser : IdentityUser
    {
        public BookingUser()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}