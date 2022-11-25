using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using cs4125.FactoryInterface;
using cs4125.Models;

namespace cs4125.Controllers
{
    public class RegisterController : Controller
    {
        // GET: MyTicketsController
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult EmailEntered(string email, string password, string password2, string name, Boolean premium)
        {
           
            UserFactory userF = new UserFactory();
            if (premium == true)
            {
                Profile profile = userF.GetProfile(ProfileType.PremiumUser, email, password, name);
                profile.writeInfoToCSV();
            }
            else { 
                Profile profile = userF.GetProfile(ProfileType.User, email, password, name);
                profile.writeInfoToCSV();
            }
      
            return View();
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
