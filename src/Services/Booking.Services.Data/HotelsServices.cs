namespace Booking.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Booking.Data.Common.Repositories;
    using Booking.Data.Models;
    using Booking.Services.Data.Contracts;
    using Booking.Services.Mapping;
    using Booking.Web.Models.Hotels;

    public class HotelsServices : IHotelsServices
    {
        private readonly IRepository<Hotel> hotelsRepository;

        public HotelsServices(IRepository<Hotel> hotelsRepository)
        {
            this.hotelsRepository = hotelsRepository;
        }

        public IEnumerable<HotelIdAndNameViewModel> GetAll()
        {
            var hotels = this.hotelsRepository.All()
                .To<HotelIdAndNameViewModel>().ToList();

            return hotels;
        }

        public HotelNameAndFloorsViewModel GetHotelById(int id)
        {
            return this.hotelsRepository.All().Where(h => h.Id == id).To<HotelNameAndFloorsViewModel>().FirstOrDefault();
        }
    }
}
