using Microsoft.AspNetCore.Mvc;

namespace EasyMed.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
