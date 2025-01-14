using Microsoft.AspNetCore.Mvc;
using TicketBooking.Repositories.Interfaces;

namespace TicketBooking.Web.Controllers
{
	public class SeatDetailsController : Controller
	{
		private readonly ISeatDetailRepo _seatDetailRepo;

		public SeatDetailsController(ISeatDetailRepo seatDetailRepo)
		{
			_seatDetailRepo = seatDetailRepo;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
