using cs4125.FactoryInterface;
using cs4125.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cs4125.Controllers
{
    public class LoginController : Controller
    {
        // GET: MyTicketsController
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(IFormCollection collection)
        {
            var email = collection["loginEmail"];
            var password = collection["loginPassword"];
            string[] data = System.IO.File.ReadAllLines("Data/LoginInformation.csv");
            for (int i = 0; i < data.Length; i++)
            {
                string[] rowData = data[i].Split(',');
                if (rowData[0] == email && rowData[1] == password)
                {
                    LoggedInUser login = LoggedInUser.GetInstance(email, password, rowData[3]);
                    return RedirectToAction("Profile", "Profile");
                }
            }
            ViewBag.error = "Can't Log in: Email and Password don't match or are not registered";
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
