namespace Booking.Web.Controllers
{
    using System;
    using Booking.Services.Data.Contracts;
    using Booking.Web.Models.Calendar;
    using Booking.Web.Models.Rooms;
    using Microsoft.AspNetCore.Mvc;

    public class RoomsController : BaseController
    {
        private readonly IRoomsService roomsServices;

        private readonly IPeriodsService periodsServices;

        private readonly IReservationsService reservationsServices;

        private readonly IHotelsService hotelsService;

        public RoomsController(IRoomsService roomsServices, 
            IPeriodsService periodsServices, 
            IReservationsService reservationsServices,
            IHotelsService hotelsService)
        {
            this.roomsServices = roomsServices;
            this.periodsServices = periodsServices;
            this.reservationsServices = reservationsServices;
            this.hotelsService = hotelsService;
        }

        [HttpGet("Rooms/{id:int}")]
        public IActionResult Details(int id, [FromQuery]YearAndMonthBindingModel query)
        {
            if (query.Month == 0) query.Month = DateTime.Now.Month;
            if (query.Year == 0)  query.Year = DateTime.Now.Year;

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
            //viewModel.Periods = this.periodsServices.GetPeriodsByRoomId(id);
            viewModel.Periods = this.periodsServices.GetPeriodsByRoomIdFilterByMonthAndYear(id, query.Month, query.Year);
            viewModel.Reservations = this.reservationsServices.GetReservationsByRoomIdFilterByMonthAndYear(id, query.Month, query.Year);
            viewModel.Hotel = this.hotelsService.GetHotelByRoomId(id);

            return this.View(viewModel);
        }
    }
}