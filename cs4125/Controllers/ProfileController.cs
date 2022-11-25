using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cs4125.Models;
using System.IO;
using Microsoft.JSInterop.Implementation;

namespace cs4125.Controllers
{
    public class ProfileController : Controller
    {
        // GET: ProfileController
        public ActionResult Profile()
        {
            /*string[] rawCSV = System.IO.File.ReadAllLines("C:\\Users\\Conor\\Documents\\CollegeWork\\LoginInformation.txt");
            string name = "JJ Collins";
            User U = new User();
            //U.Email = "test.email@example.com";
            U.Name = "JJ Collins";
            */

            LoggedInUser loggedInUser = LoggedInUser.GetInstance("", "");
            String ProfileName = loggedInUser.Email;

            ViewBag.Name =  ProfileName;
            return View();
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
