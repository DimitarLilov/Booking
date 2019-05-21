namespace Booking.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class RoomsController : BaseController
    {
        [HttpGet("Rooms/{id:int}")]
        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}