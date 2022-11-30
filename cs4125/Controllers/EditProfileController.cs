using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cs4125.Models;
using System.IO;
using Microsoft.JSInterop.Implementation;
using cs4125.FactoryInterface;

namespace cs4125.Controllers
{
    public class EditProfileController : Controller
    {
        // GET: ProfileController
        public ActionResult EditProfile()
        {
            
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(IFormCollection collection)
        {
            LoggedInUser loggedInUser = LoggedInUser.GetInstance("", "", "");
            var email = loggedInUser.Email;
            var oldPassword = collection["registrationOldPassword"];
            var password = collection["registrationPassword"];
            var password2 = collection["registrationPassword2"];
            var name = collection["registrationName"];
            var photo = collection["registrationPhoto"];
            var premium = collection["registrationPremium"];
            string csvFile = System.IO.File.ReadAllText("Data/LoginInformation.csv");
            string[] data = System.IO.File.ReadAllLines("Data/LoginInformation.csv");

            if (password != "")
            {
                if (oldPassword == loggedInUser.Password)
                {
                    if (password == password2)
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            string[] rowData = data[i].Split(',');
                            if (rowData[0] == email && rowData[1] == loggedInUser.Password)
                            {
                                string newCSVFile = csvFile.Replace(loggedInUser.Password, password);
                                System.IO.File.WriteAllText("Data/LoginInformation.csv", newCSVFile);
                                loggedInUser.Password = password;
                            }
                        }
                    }
                    else
                    {
                        ViewBag.error = "New passwords do not match";
                        return View();
                    }
                } 
                else 
                {
                    ViewBag.error = "Old password is incorrect";
                    return View();
                }
                      
            }

            if (name != "")
            {
                for (int i = 0; i < data.Length; i++)
                {
                    string[] rowData = data[i].Split(',');
                    if (rowData[0] == email && rowData[1] == loggedInUser.Password)
                    {
                        string newCSVFile = csvFile.Replace(loggedInUser.Name, name);
                        System.IO.File.WriteAllText("Data/LoginInformation.csv", newCSVFile);
                        loggedInUser.Name = name;
                    }
                }
            }

            if (photo != "")
            {
                for (int i = 0; i < data.Length; i++)
                {
                    string[] rowData = data[i].Split(',');
                    if (rowData[0] == email && rowData[1] == loggedInUser.Password)
                    {
                        string newCSVFile = csvFile.Replace(loggedInUser.photo, photo);
                        System.IO.File.WriteAllText("Data/LoginInformation.csv", newCSVFile);
                        loggedInUser.photo = photo;
                    }
                }
            }

            return RedirectToAction("Profile", "Profile");
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
