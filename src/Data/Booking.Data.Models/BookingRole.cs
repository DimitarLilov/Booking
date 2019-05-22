namespace Booking.Data.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class BookingRole : IdentityRole
    {
        public BookingRole()
            : this(null)
        {
        }

        public BookingRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
