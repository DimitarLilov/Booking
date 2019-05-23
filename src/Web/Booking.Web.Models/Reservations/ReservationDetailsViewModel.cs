namespace Booking.Web.Models.Reservations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Booking.Data.Models;
    using Booking.Services.Mapping.Contracts;
    using Booking.Web.Models.Users;

    public class ReservationDetailsViewModel : IMapFrom<Reservation>, IHaveCustomMappings
    {
        public UserNamesViewModel User { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Reservation, ReservationDetailsViewModel>()
               .ForMember(r => r.Date,
                   m => m.MapFrom(r => r.ReservationDate));
        }
    }
}
