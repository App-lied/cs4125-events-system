using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cs4125.Controllers
{
    [Authorize]
    public class InformationController : Controller
    {
        [AllowAnonymous]
        public IActionResult Information()
        {
            return View();
        }
    }
}
