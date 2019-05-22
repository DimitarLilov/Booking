using Microsoft.AspNetCore.Mvc;

namespace Booking.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationBaseController
    {
        
        public IActionResult Index()
        {
            return this.View();
        }
    }
}