using Microsoft.AspNetCore.Mvc;

namespace cs4125.Controllers
{
    public class EditProfileController : Controller
    {
        // GET: ProfileController
        public ActionResult EditProfile()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(IFormCollection collection)
        {
            //uses singleton method to get the Email
            LoggedInUser loggedInUser = LoggedInUser.GetInstance("", "", "");
            var email = loggedInUser.Email;
            var oldPassword = collection["registrationOldPassword"];
            var password = collection["registrationPassword"];
            var password2 = collection["registrationPassword2"];
            var name = collection["registrationName"];
            var photo = collection["registrationPhoto"];
            
            //reads in csv file information and stores all lines in an array
            string csvFile = System.IO.File.ReadAllText("Data/LoginInformation.csv");
            string[] data = System.IO.File.ReadAllLines("Data/LoginInformation.csv");

            //series of checks to see if new values were collected in the form for password, name and photo
            //If there are changes, it performs necessary checks before replacing the information in the csvFile and rewriting it
            if (password != "")
            {
                if (oldPassword == loggedInUser.Password)
                {
                    if (password == password2)
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            string[] rowData = data[i].Split('#');
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
                        //returns error and refreshes page
                        ViewBag.error = "New passwords do not match";
                        return View();
                    }
                } 
                else 
                {
                    //returns error and refreshes page
                    ViewBag.error = "Old password is incorrect";
                    return View();
                }
                      
            }

            if (name != "")
            {
                for (int i = 0; i < data.Length; i++)
                {   
                    string[] rowData = data[i].Split('#');
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
                    string[] rowData = data[i].Split('#');
                    if (rowData[0] == email && rowData[1] == loggedInUser.Password)
                    {
                        string newCSVFile = csvFile.Replace(loggedInUser.photo, photo);
                        System.IO.File.WriteAllText("Data/LoginInformation.csv", newCSVFile);
                        loggedInUser.photo = photo;
                    }
                }
            }

            //returns to the profile page
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
