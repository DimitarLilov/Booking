namespace Booking.Web.Models.Calendar
{
    using System.ComponentModel.DataAnnotations;

    public class YearAndMonthBindingModel
    {
        [Range(0, 12)]
        public int Month { get; set; }

        [Range(0, 9999)]
        public int Year { get; set; }
    }
}
