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

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var hotel = this.hotelsServices.GetHotelById(id);

            return this.View(hotel);
        }
    }
}