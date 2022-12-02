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
            //reads in the form details
            var email = collection["registrationEmail"];
            var password = collection["registrationPassword"];
            var password2 = collection["registrationPassword2"];
            var name = collection["registrationName"];
            var premium = collection["registrationPremium"];
            var eventorganiser = collection["registrationOrganiser"];
            DateTime birth = DateTime.Parse(collection["registrationDate"]);

            //checks the passwords match
            if (password == password2)
            {
                if (eventorganiser == "on")
                {
                    //creates Event Organsier factory
                    EventOrganiserFactory userFevent = new EventOrganiserFactory();
                    //uses factory method to create Event Organiser with the Profile Type Enum
                    Profile profile = userFevent.GetProfile(ProfileType.EventOrganiser, email, password, name, birth);
                    //Checks if the age is greater than 16 and returns error if not
                    if (profile.getAge() <= 16)
                    {
                        ViewBag.error = "Profile not created: Must be over 16 years old";
                        return View();
                    }
                    else
                    {
                        //writes the information to the login information csv and sets the singleton to the registered user
                        profile.writeInfoToCSV();
                        LoggedInUser login = LoggedInUser.GetInstance(email, password, name);
                        CLIDisplay display = new CLIDisplay();
                        return RedirectToAction("Profile", "Profile");
                    }
                }

                //follows the same format as event organiser factory but checks if the account is premimum or not and acts accordingly
                //creates a User Factory
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