namespace Booking.Web.Areas.Administration.Controllers
{
    using Booking.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class ReservationsController : AdministrationBaseController
    {
        private readonly IReservationsService reservationsService;

        public ReservationsController(IReservationsService reservationsService)
        {
            this.reservationsService = reservationsService;
        }

        public IActionResult Index()
        {
            var viewModel = this.reservationsService.GetAllReservation();

            return View(viewModel);
        }
    }
}