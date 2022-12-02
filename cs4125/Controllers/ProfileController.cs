using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cs4125.Models;
using System.IO;
using Microsoft.JSInterop.Implementation;
using static System.Net.WebRequestMethods;

namespace cs4125.Controllers
{
    public class ProfileController : Controller
    {
        // GET: ProfileController
        public ActionResult Profile()
        {
            //uses singleton method to lock in a user as the logged in user

            //uses the createdIfNeeded boolean operator to choose to not create a new instance so that it can check if one is created
            //if one is created, it will load profile with the necessary information, otherwise it redirects to the login page
            LoggedInUser UserCheck = LoggedInUser.GetInstance("", "", "", "", false);
            if (UserCheck != null)
            {
                LoggedInUser loggedInUser = LoggedInUser.GetInstance("", "", "");

                ViewBag.Photo = loggedInUser.photo;
                ViewBag.Name = loggedInUser.Name;
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileController/Create
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

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileController/Edit/5
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

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
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
