namespace Booking.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Booking.Data.Common.Repositories;
    using Booking.Data.Models;
    using Booking.Services.Data.Contracts;
    using Booking.Services.Mapping;
    using Booking.Web.Models.Hotels;

    public class HotelsService : IHotelsService
    {
        private readonly IRepository<Hotel> hotelsRepository;

        public HotelsService(IRepository<Hotel> hotelsRepository)
        {
            this.hotelsRepository = hotelsRepository;
        }

        public bool ContainsFloor(int id, int floor)
        {
            var hotel = this.GetHotelById(id);
            if (floor > hotel.Floors || floor <= 0)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<HotelIdAndNameViewModel> GetAll()
        {
            var hotels = this.hotelsRepository.All()
                .To<HotelIdAndNameViewModel>().ToList();

            return hotels;
        }

        public HotelViewModel GetHotelById(int id)
        {
            return this.hotelsRepository.All().Where(h => h.Id == id).To<HotelViewModel>().FirstOrDefault();
        }

        public HotelIdAndNameViewModel GetHotelByRoomId(int id)
        {
            return this.hotelsRepository.All().Where(h => h.Rooms.Any(r => r.Id == id)).To<HotelIdAndNameViewModel>().FirstOrDefault();
        }

        public HotelFloorRoomsViewModel GetRoomByHotelIdAndFloor(int hotelId, int floor)
        {
            var hotel = this.hotelsRepository.All().Where(h => h.Id == hotelId).To<HotelFloorRoomsViewModel>().FirstOrDefault();
            hotel.Rooms = hotel.Rooms.Where(r => r.Floor == floor).ToList();
            hotel.Floor = floor;

            return hotel;
        }
    }
}
