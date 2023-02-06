/*using AspNetCore;
using Microsoft.AspNetCore.Http;*/
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MP1.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MP1.ViewModels;

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
            String username = HttpContext.Session.GetString("user");
            if (username == null)
                return Redirect($"http://localhost:5277/");
            else
                return View(list);
        }

        // GET: UserDetailsController/Details/5
        public ActionResult Details(int id)
        {         
            String username = HttpContext.Session.GetString("user");
            if (username == null)
            {
                return Redirect($"http://localhost:5277/");
            } 
            else
            {
                UserDetails u = UserDetails.DisplaySingleDetails(id);
                if (u.Id == id)
                {
                    return View(u);
                }
                return View(u);
            }
        }

       
        // GET: UserDetailsController/Create
        public ActionResult Create()
        {
            UserModel u = new UserModel();
            List<SelectListItem> cl = CityDetails.GetAllList();
            u.CityList = cl;
            return View(u);
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

            String username = HttpContext.Session.GetString("user");
            if (username == null)
                return Redirect($"http://localhost:5277/");
            else
            { 
                UserDetails u = UserDetails.DisplaySingleDetails(id);
                UserModel u1= new UserModel();
                u1.Id = u.Id;
                u1.UserName = u.UserName;
                u1.FullName= u.FullName;
                u1.Password = u.Password;
                u1.PhoneNumber = u.PhoneNumber;
                u1.EmailId = u.EmailId;
                u1.Gender= u.Gender;
                u1.Password=u.Password;
                List<SelectListItem> cl = CityDetails.GetAllList();
                u1.CityList = cl;
                ViewBag.CityDetail = cl;
                Console.WriteLine("Inside mY Controller");
                Console.WriteLine(u.Gender);
                return View(u);
            }
        }
        public ActionResult Edit1(int id)
        {

            String username = HttpContext.Session.GetString("user");
            if (username == null)
                return Redirect($"http://localhost:5277/");
            else
            {
                UserDetails u = UserDetails.DisplaySingleDetails(id);
                UserModel u1 = new UserModel();
                u1.Id = u.Id;
                u1.UserName = u.UserName;
                u1.FullName = u.FullName;
                u1.Password = u.Password;
                u1.PhoneNumber = u.PhoneNumber;
                u1.EmailId = u.EmailId;
                u1.Gender = u.Gender;
                u1.Password = u.Password;
                List<SelectListItem> cl = CityDetails.GetAllList();
                u1.CityList = cl;
                ViewBag.CityDetail = cl;
                Console.WriteLine("Inside mY Controller");
                Console.WriteLine(u.Gender);
                return View(u1);
            }
        }

        // POST: UserDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection,UserDetails u)
        {
            try
            {
                Console.WriteLine(u.UserName);
                Console.WriteLine(u.Id);
                Console.WriteLine("Update try block entered");
                UserDetails.UpdateUser(u);
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
            String username = HttpContext.Session.GetString("user");
            if (username == null)
                return Redirect($"http://localhost:5277/");
            else
            { 
                UserDetails u = UserDetails.DisplaySingleDetails(id);
                return View(u);
            }
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
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(string username,string password,IFormCollection collection,UserDetails u,bool CheckBox)
        {
            if(CheckBox==true)
            {
                Console.WriteLine(" This is for Checkbox int login page");
            }
            else
            { Console.WriteLine("NOt working"); }
            
            UserDetails u1=UserDetails.DisplayLogin(u.UserName,u.Password);
            if(u1!= null)
            {
                string jsonUser=JsonSerializer.Serialize<UserDetails>(u1);
                HttpContext.Session.SetString("user", jsonUser);
                return Redirect($"UserDetails/HomePage");
               /* return Redirect($"Home/Index");*/
               /* return Redirect($"UserDetails/Details/{u1.Id}");*/
            }
            else
            {
                ViewBag.a = "Wrong Credentials Entered";
                return View();
            }
        }

        public ActionResult HomePage() 
        {
            String username=HttpContext.Session.GetString("user");
            if (username == null)
                return Redirect($"http://localhost:5277/");
            else
                return View();
        }

        public ActionResult ViewCityWise()
        {
            String username = HttpContext.Session.GetString("user");
            if (username == null)
            {
                return Redirect($"http://localhost:5277/");
            }
            else
            {
                List<UserDetails> users = new List<UserDetails>();
                users = UserDetails.DisplayAll();
                List<UserModel> models = new List<UserModel>();
                foreach (UserDetails user in users)
                {
                    models.Add(new UserModel { Id = user.Id, UserName = user.UserName, FullName = user.FullName, Gender = user.Gender, EmailId = user.EmailId, PhoneNumber = user.PhoneNumber, CityName = CityDetails.SelectCity(user.City).CityName });
                }
                return View(models);
            }
        }
    }
}
