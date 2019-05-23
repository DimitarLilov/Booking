namespace Booking.Web.Models.Periods
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class PeriodViewModel : IMapFrom<Period>
    {
        public decimal Price { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EndDate { get; set; }
    }
}
