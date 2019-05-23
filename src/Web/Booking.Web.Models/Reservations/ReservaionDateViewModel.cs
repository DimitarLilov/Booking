namespace Booking.Web.Models.Reservations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;

    public class ReservaionDateViewModel : IMapFrom<Reservation>, IHaveCustomMappings
    {
        [Display(Name = "Reservation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ReservationDate { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Reservation, ReservaionDateViewModel>()
                .ForMember(r => r.ReservationDate,
                    m => m.MapFrom(r => r.ReservationDate));
        }
    }
}
