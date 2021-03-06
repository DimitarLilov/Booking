﻿namespace Booking.Web.Models.Periods
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class CreatePeriodBindingModel : IMapTo<Period>
    {
        [Required]
        public int RoomId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
