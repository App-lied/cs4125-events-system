using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using cs4125.FactoryInterface;
using cs4125.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace cs4125.Controllers
{
    public class RegisterController : Controller
    {
        // GET: MyTicketsController
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection collection)
        {
            var email = collection["registrationEmail"];
            var password = collection["registrationPassword"];
            var password2 = collection["registrationPassword2"];
            var name = collection["registrationName"];
            var premium = collection["registrationPremium"];
            DateTime birth = DateTime.Parse(collection["registrationDate"]);
            if (password == password2)
            {
                UserFactory userF = new UserFactory();
                if (premium == "on")
                {
                    Profile profile = userF.GetProfile(ProfileType.PremiumUser, email, password, name, birth);
                    if (profile.getAge() <= 16)
                    {
                        ViewBag.error = "Profile not created: Must be over 16 years old";
                        return View();
                    }
                    else
                    {
                        profile.writeInfoToCSV();
                        LoggedInUser login = LoggedInUser.GetInstance(email, password, name);
                        return RedirectToAction("Profile", "Profile");
                    }
                }
                else
                {
                    Profile profile = userF.GetProfile(ProfileType.User, email, password, name, birth);
                    if (profile.getAge() <= 16)
                    {
                        ViewBag.error = "Profile not created: Must be over 16 years old";
                        return View();
                    }
                    else
                    {
                        profile.writeInfoToCSV();
                        LoggedInUser login = LoggedInUser.GetInstance(email, password, name);
                        return RedirectToAction("Profile", "Profile");
                    }
                }
            }
            else
            {
                ViewBag.error = "Profile not created: Passwords don't match";
                return View();
            }
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
