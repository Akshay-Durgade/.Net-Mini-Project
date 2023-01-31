using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MP1.Models;

namespace MP1.Controllers
{
    public class UserDetailsController : Controller
    {
        // GET: UserDetailsController
        public ActionResult Index()
        {
            List<UserDetails> list=UserDetails.DisplayAll();
            foreach(var e in list)
            {
                Console.WriteLine(e.Id+"\t"+e.FullName);
            }
            return View(list);
        }

        // GET: UserDetailsController/Details/5
        public ActionResult Details(int id)
        {         
            UserDetails u=UserDetails.DisplaySingleDetails(id);
            if (u.Id == id)
            {
                return View(u);
            }
            return View(u);
        }

        // GET: UserDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,UserDetails u)
        {
            try
            {
                UserDetails.Insert(u);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            UserDetails u = UserDetails.DisplaySingleDetails(id);
            Console.WriteLine("Inside mY Controller");
            Console.WriteLine(u.Gender);
            return View(u);
        }

        // POST: UserDetailsController/Edit/5
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

        // GET: UserDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            UserDetails u = UserDetails.DisplaySingleDetails(id);
            return View(u);
        }

        // POST: UserDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                UserDetails.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserDetailsController/LoginPage/5
        public ActionResult LoginPage(string username,string password)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(string username,string password,IFormCollection collection,UserDetails u)
        {
            UserDetails u1=UserDetails.DisplayLogin(u.UserName,u.Password);
            if(u1!= null)
            {
                return Redirect($"UserDetails/Details/{u1.Id}");
            }
            else
            {
                ViewBag.a = "Wrong Credentials Entered";
                return View();
            }
        }
    }
}
