using Microsoft.AspNetCore.Mvc;

namespace HMS.Presentation.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
