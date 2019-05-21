namespace Booking.Web.Controllers
{
    using Booking.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class HotelsController : BaseController
    {
        private readonly IHotelsServices hotelsServices;

        public HotelsController(IHotelsServices hotelsServices)
        {
            this.hotelsServices = hotelsServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var hotels = this.hotelsServices.GetAll();

            return this.View(hotels);
        }

        [HttpGet("Hotels/{id:int}")]
        public IActionResult Details(int id)
        {
            var hotel = this.hotelsServices.GetHotelById(id);

            if(hotel == null)
            {
                return this.NotFound();
            }

            return this.View(hotel);
        }

        [HttpGet("Hotels/{id:int}/Floors/{floorNumber:int}")]
        public IActionResult Floor(int id, int floorNumber)
        {
            var hotel = this.hotelsServices.GetHotelById(id);
            if (hotel == null)
            {
                return this.NotFound();
            }
            if (!this.hotelsServices.ContainsFloor(id, floorNumber))
            {
                return this.NotFound();
            }

            var floorRooms = hotelsServices.GetRoomByHotelIdAndFloor(id, floorNumber);

            return this.View(floorRooms);
        }
    }
}