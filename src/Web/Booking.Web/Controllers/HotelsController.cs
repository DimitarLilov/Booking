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

        [HttpGet("Hotels/{id:int}/Floors/")]
        public IActionResult Floor(int id, string floorNumber)
        {
            var hotel = this.hotelsServices.GetHotelById(id);
            if (hotel == null)
            {
                return this.NotFound();
            }
            if (floorNumber == null)
            {
                return this.NotFound();
            }
            var floor = int.Parse(floorNumber);
            if (!this.hotelsServices.ContainsFloor(id,floor))
            {
                return this.NotFound();
            }

            var floorRooms = hotelsServices.GetRoomByHotelIdAndFloor(id,floor);

            return this.View(floorRooms);
        }
    }
}