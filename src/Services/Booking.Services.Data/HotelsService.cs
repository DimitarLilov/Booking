namespace Booking.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
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
            var hotel = this.GetHotelQyerById(id).FirstOrDefault();
            if (floor > hotel.Floors || floor <= 0)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<HotelIdAndNameViewModel> GetAll()
        {
            return this.GetHotelsInfo().To<HotelIdAndNameViewModel>().ToList();
        }

        public IEnumerable<HotelViewModel> GetAllHotelsInfo()
        {
            return this.GetHotelsInfo().To<HotelViewModel>().ToList();
        }

        public HotelViewModel GetHotelById(int id)
        {
            return this.GetHotelQyerById(id).To<HotelViewModel>().FirstOrDefault();
        }

        public HotelIdAndNameViewModel GetHotelByRoomId(int id)
        {
            return this.GetHotelsInfo(h => h.Rooms.Any(r => r.Id == id)).To<HotelIdAndNameViewModel>().FirstOrDefault();
        }

        public HotelDetailsViewModel GetHotelDetails(int id)
        {
            return this.GetHotelQyerById(id).To<HotelDetailsViewModel>().FirstOrDefault();
        }

        public HotelFloorRoomsViewModel GetRoomByHotelIdAndFloor(int hotelId, int floor)
        {
            var hotel = this.GetHotelQyerById(hotelId).To<HotelFloorRoomsViewModel>().FirstOrDefault();
            hotel.Rooms = hotel.Rooms.Where(r => r.Floor == floor).ToList();
            hotel.Floor = floor;

            return hotel;
        }

        private IQueryable<Hotel> GetHotelQyerById(int id)
        {
            return this.GetHotelsInfo(h => h.Id == id);
        }

        private IQueryable<Hotel> GetHotelsInfo(
            Expression<Func<Hotel, bool>> predicate = null,
            Expression<Func<Hotel, object>> orderBySelector = null,
            int? skip = null,
            int? take = null)
        {
            IQueryable<Hotel> songsQuery = this.hotelsRepository.All();
            if (predicate != null)
            {
                songsQuery = songsQuery.Where(predicate);
            }

            if (orderBySelector != null)
            {
                songsQuery = songsQuery.OrderBy(orderBySelector);
            }

            if (skip != null)
            {
                songsQuery = songsQuery.Skip(skip.Value);
            }

            if (take != null)
            {
                songsQuery = songsQuery.Take(take.Value);
            }

            return songsQuery;
        }
    }
}
