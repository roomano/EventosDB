using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnventosDB.MVC.Controllers
{
    public class GuestController : Controller
    {
        // GET: GuestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GuestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GuestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestController/Create
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

        // GET: GuestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GuestController/Edit/5
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

        // GET: GuestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GuestController/Delete/5
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
