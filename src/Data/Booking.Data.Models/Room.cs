namespace Booking.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Booking.Data.Common.Models;

    public class Room : BaseModel<int>
    {
        public Room()
        {
            this.Periods = new HashSet<Period>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public virtual ICollection<Period> Periods { get; set; }
    }
}
