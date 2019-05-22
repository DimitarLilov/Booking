namespace Booking.Web.Areas.Administration.Controllers
{
    using Booking.Services.Data.Contracts;
    using Booking.Web.Models.Hotels;
    using Booking.Web.Models.Rooms;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HotelsController : AdministrationBaseController
    {
        private readonly IHotelsService hotelsServices;

        private readonly IRoomsService roomsService;

        public HotelsController(IHotelsService hotelsServices, IRoomsService roomsService)
        {
            this.hotelsServices = hotelsServices;
            this.roomsService = roomsService;
        }

        [HttpGet("Administration/Hotels")]
        public IActionResult Index()
        {
            IEnumerable<HotelViewModel> viewModel = this.hotelsServices.GetAllHotelsInfo();

            return this.View(viewModel);
        }

        [HttpGet("Administration/Hotels/{id:int}")]
        public IActionResult Details(int id)
        {
            HotelDetailsViewModel viewMode = this.hotelsServices.GetHotelDetails(id);

            return this.View(viewMode);
        }

        [HttpGet("Administration/Hotels/{id:int}/Room")]
        public IActionResult Room(int id)
        {
            var viewMode = this.hotelsServices.GetHotelById(id);
            return this.View(viewMode);
        }

        [HttpPost("Administration/Hotels/{id:int}/Room")]
        public async Task<IActionResult> Room(int id, CreateRoomBindingModel bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                await this.roomsService.CreateRoomAsync(id, bindingModel);
                return this.RedirectToAction(nameof(Details), new { id});
            }

            var viewMode = this.hotelsServices.GetHotelById(id);
            return this.View(viewMode);
        }
    }
}