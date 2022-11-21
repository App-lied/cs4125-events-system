using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cs4125.Controllers
{
    public class RegisterController : Controller
    {
        // GET: MyTicketsController
        public ActionResult Register()
        {
           // string strEmail = form["password"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult EmailEntered()
        {
           

            return Content("Account Created");
        }

        // GET: MyTicketsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyTicketsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyTicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyTicketsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyTicketsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyTicketsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyTicketsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
