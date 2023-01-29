using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MP1.Controllers
{
    public class UserDetailsController : Controller
    {
        // GET: UserDetailsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetailsController/Create
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

        // GET: UserDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
            return View();
        }

        // POST: UserDetailsController/Delete/5
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
