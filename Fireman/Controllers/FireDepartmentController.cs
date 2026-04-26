using FIREMAN.Data;
using FIREMAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class FireDepartmentController : Controller
{
    private readonly FireDbContext _context;

    public FireDepartmentController(FireDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
        => View(await _context.FireStations.ToListAsync());

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var item = await _context.FireStations.FirstOrDefaultAsync(x => x.StationId == id);
        if (item == null) return NotFound();

        return View(item);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(FireDepartment item)
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

        var item = await _context.FireStations.FindAsync(id);
        if (item == null) return NotFound();

        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, FireDepartment item)
    {
        if (id != item.StationId) return NotFound();

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

        var item = await _context.FireStations.FirstOrDefaultAsync(x => x.StationId == id);
        if (item == null) return NotFound();

        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.FireStations.FindAsync(id);
        _context.FireStations.Remove(item);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}