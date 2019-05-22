namespace Booking.Services.Data
{
    using System.Linq;
    using Booking.Data.Common.Repositories;
    using Booking.Data.Models;
    using Booking.Services.Data.Contracts;
    using Booking.Services.Mapping;
    using Booking.Web.Models.Rooms;

    public class RoomsService : IRoomsService
    {
        private readonly IRepository<Room> roomsRepository;

        public RoomsService(IRepository<Room> roomsRepository)
        {
            this.roomsRepository = roomsRepository;
        }

        public RoomViewModel GetRoomByRoomId(int id)
        {
            return this.roomsRepository.All().Where(r => r.Id == id).To<RoomViewModel>().FirstOrDefault();
        }
    }
}
