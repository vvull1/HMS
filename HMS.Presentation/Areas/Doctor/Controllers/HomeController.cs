using Microsoft.AspNetCore.Mvc;

namespace HMS.Presentation.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ManageAppointment()
        {
            return View();
        }

        public IActionResult ManagePatient()
        {
            return View();
        }
    }
}
