using FIREMAN.Data;
using FIREMAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIREMAN.Controllers
{
    public class ShiftController : Controller
    {
        private readonly FireDbContext _context;

        public ShiftController(FireDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var shifts = await _context.Shifts
                .Include(s => s.Employee)
                .Include(s => s.FireTruck)
                .ToListAsync();

            return View(shifts);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Employees = await _context.Employees.ToListAsync();
            ViewBag.FireTrucks = await _context.FireVehicles.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DateTime date, int? employeeId, int? fireTruckId)
        {
            var shift = new Shift
            {
                Date = date,
                EmployeeId = employeeId,
                FireTruckId = fireTruckId
            };

            _context.Shifts.Add(shift);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var shift = await _context.Shifts.FindAsync(id);
            if (shift == null) return NotFound();

            ViewBag.Employees = await _context.Employees.ToListAsync();
            ViewBag.FireTrucks = await _context.FireVehicles.ToListAsync();

            return View(shift);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, int? employeeId, int? fireTruckId)
        {
            var shift = await _context.Shifts.FindAsync(id);
            if (shift == null) return NotFound();

            shift.EmployeeId = employeeId;     // null → маха пожарникаря
            shift.FireTruckId = fireTruckId;   // null → маха колата

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
