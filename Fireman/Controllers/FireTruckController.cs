using FIREMAN.Data;
using FIREMAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class FireTruckController : Controller
{
    private readonly FireDbContext _context;

    public FireTruckController(FireDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
        => View(await _context.FireVehicles.ToListAsync());

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var item = await _context.FireVehicles.FirstOrDefaultAsync(x => x.VehicleId == id);
        if (item == null) return NotFound();

        return View(item);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(FireTruck item)
    {
        if (ModelState.IsValid)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(item);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var item = await _context.FireVehicles.FindAsync(id);
        if (item == null) return NotFound();

        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, FireTruck item)
    {
        if (id != item.VehicleId) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(item);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var item = await _context.FireVehicles.FirstOrDefaultAsync(x => x.VehicleId == id);
        if (item == null) return NotFound();

        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.FireVehicles.FindAsync(id);
        _context.FireVehicles.Remove(item);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}