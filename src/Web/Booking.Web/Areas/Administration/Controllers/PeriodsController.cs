namespace Booking.Web.Areas.Administration.Controllers
{
    using Booking.Services.Data.Contracts;
    using Booking.Web.Models.Periods;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PeriodsController : AdministrationBaseController
    {
        private readonly IPeriodsService periodsService;

        private readonly IReservationsService reservationsService;

        public PeriodsController(IPeriodsService periodsService, IReservationsService reservationsService)
        {
            this.periodsService = periodsService;
            this.reservationsService = reservationsService;
        }

        public IActionResult Index()
        {
            var viewModels = this.periodsService.GetAllPeriods();

            return View(viewModels);
        }

        public IActionResult Edit(int id)
        {
            var viewModel = this.periodsService.GetPeriodById(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPeriodBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                await this.periodsService.EditPeriod(id, bindingModel);
                return this.RedirectToAction("Index");
            }

            var viewModel = this.periodsService.GetPeriodById(id);
            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var period = this.periodsService.GetPeriodById(id);
            var viewModel = new PeriodDetailsViewModel
            {
                Period = period,
                Reservations = this.reservationsService.GetReservationsDetailsByRoomId(period.Room.Id)
            };
            return this.View(viewModel);
        }
    }
}