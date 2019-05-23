namespace Booking.Web.Areas.Administration.Controllers
{
    using Booking.Services.Data.Contracts;
    using Booking.Web.Models.Periods;
    using Booking.Web.Models.Rooms;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class RoomsController : AdministrationBaseController
    {
        private readonly IRoomsService roomsService;

        private readonly IReservationsService reservationsService;

        private readonly IPeriodsService periodsService;

        public RoomsController(IReservationsService reservationsService, IRoomsService roomsService, IPeriodsService periodsService)
        {
            this.reservationsService = reservationsService;
            this.roomsService = roomsService;
            this.periodsService = periodsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.roomsService.GetAllRooms();

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var viewModel = this.roomsService.GetEditRoom(id);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRoomBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                await this.roomsService.EditRoom(id, bindingModel);

                return this.RedirectToAction("Index");
            }

            var viewModel = this.roomsService.GetEditRoom(id);

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var viewModel = this.roomsService.GetRoomDetails(id);
            viewModel.Reservations = this.reservationsService.GetReservationsByRoomId(id);
            return View(viewModel);
        }


        [HttpGet("Administration/Rooms/{id:int}/Periods")]
        public IActionResult Periods(int id)
        {
            var viewModel = this.roomsService.GetRoomPeriods(id);
            return this.View(viewModel);
        }

        [HttpGet("Administration/Rooms/{id:int}/Periods/Create")]
        public IActionResult CreatePeriod(int id)
        {
            var viewModel = new CreatePeriodViewModel
            {
                RoomId = id
            };

            return this.View(viewModel);
        }

        [HttpPost("Administration/Rooms/{id:int}/Periods/Create")]
        public async Task<IActionResult> CreatePeriod(CreatePeriodBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                await this.periodsService.CreatePeriodAsync(bindingModel);
                
                return this.RedirectToAction("Periods", new { id = bindingModel.RoomId});
            }

            var viewModel = new CreatePeriodViewModel
            {
                RoomId = bindingModel.RoomId
            };

            return this.View(viewModel);
        }
    }
}