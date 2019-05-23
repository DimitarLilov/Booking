using AutoMapper;
using Booking.Data.Models;
using Booking.Services.Mapping.Contracts;

namespace Booking.Web.Models.Rooms
{
    public class RoomAdminViewModel : IMapFrom<Room>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int Floor { get; set; }

        public string Name { get; set; }

        public string Hotel { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Room, RoomAdminViewModel>()
                .ForMember(x => x.Hotel,
                    m => m.MapFrom(r => r.Hotel.Name));
        }
    }
}
