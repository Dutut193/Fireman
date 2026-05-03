using Microsoft.AspNetCore.Mvc;
using FIREMAN.Models;

namespace FIREMAN.Controllers
{
    public class ShiftController : Controller
    {
        private static List<Shift> Shifts = new List<Shift>();
        private static int Counter = 1;

        public IActionResult Index()
        {
            return View(Shifts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Shift model)
        {
            model.Id = Counter++;
            Shifts.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = Shifts.FirstOrDefault(x => x.Id == id);
            if (item != null)
                Shifts.Remove(item);

            return RedirectToAction("Index");
        }
    }
}
