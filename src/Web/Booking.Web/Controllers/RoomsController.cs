namespace Booking.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Booking.Data.Models;
    using Booking.Services.Data.Contracts;
    using Booking.Web.Models.Calendar;
    using Booking.Web.Models.Reservations;
    using Booking.Web.Models.Rooms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RoomsController : BaseController
    {
        private readonly IRoomsService roomsServices;

        private readonly IPeriodsService periodsServices;

        private readonly IReservationsService reservationsServices;

        private readonly IHotelsService hotelsService;

        private readonly UserManager<BookingUser> userManager;

        public RoomsController(
            IRoomsService roomsServices,
            IPeriodsService periodsServices,
            IReservationsService reservationsServices,
            IHotelsService hotelsService,
            UserManager<BookingUser> userManager)
        {
            this.roomsServices = roomsServices;
            this.periodsServices = periodsServices;
            this.reservationsServices = reservationsServices;
            this.hotelsService = hotelsService;
            this.userManager = userManager;
        }

        [HttpGet("Rooms/{id:int}")]
        public IActionResult Details(int id, [FromQuery]YearAndMonthBindingModel query)
        {
            if (query.Month == 0)
            {
                query.Month = DateTime.Now.Month;
            }

            if (query.Year == 0)
            {
                query.Year = DateTime.Now.Year;
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var viewModel = new RoomDetailsViewModel()
            {
                Year = query.Year,
                Month = query.Month
            };

            viewModel.Room = this.roomsServices.GetRoomByRoomId(id);
            viewModel.Periods = this.periodsServices.GetPeriodsByRoomIdFilterByMonthAndYear(id, query.Month, query.Year);
            viewModel.Reservations = this.reservationsServices.GetReservationsByRoomIdFilterByMonthAndYear(id, query.Month, query.Year);
            viewModel.Hotel = this.hotelsService.GetHotelByRoomId(id);

            return this.View(viewModel);
        }

        [HttpGet("Rooms/{id:int}/Reservation")]
        public IActionResult Reservation(int id, [FromQuery]DateModel query)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (this.reservationsServices.RoomIsReserved(id, query.Date))
            {
                return this.RedirectToAction("Reserved", new { id, query.Date });
            }

            if (!this.periodsServices.RoomIsAvailable(id, query.Date) || query.Date < DateTime.Now)
            {
                return this.RedirectToAction("NotAvailable");
            }

            var viewModel = new ReservationViewModel
            {
                Room = this.roomsServices.GetRoomByRoomId(id),
                Hotel = this.hotelsService.GetHotelByRoomId(id),
                Date = query.Date,
                Price = this.periodsServices.GetPriceByPeriod(query.Date)
            };

            return this.View(viewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost("Rooms/Reservation")]
        public async Task<IActionResult> Reservation(ReservationRoomBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.reservationsServices.ReservationRoom(bindingModel, userId);

            return this.RedirectToAction("Details", "Rooms", new { id = bindingModel.RoomId });
        }

        [HttpGet("Rooms/{id:int}/Reserved")]
        public IActionResult Reserved(int id, [FromQuery]DateModel query)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (!this.reservationsServices.RoomIsReserved(id, query.Date))
            {
                return this.NotFound();
            }

            return this.View(query);
        }

        [HttpGet("Rooms/NotAvailable")]
        public IActionResult NotAvailable()
        {
            return this.View();
        }
    }
}