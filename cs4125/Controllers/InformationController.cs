using Microsoft.AspNetCore.Mvc;

namespace cs4125.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Information()
        {
            return View();
        }
    }
}
