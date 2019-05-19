namespace Booking.Data.Models
{
    using System.Collections.Generic;
    using Booking.Data.Common.Models;

    public class Hotel : BaseModel<int>
    {
        public Hotel()
        {
            this.Rooms = new HashSet<Room>();
        }

        public string Name { get; set; }

        public int Floors { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
