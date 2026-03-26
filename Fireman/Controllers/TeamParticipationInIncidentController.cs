using FIREMAN.Data;
using FIREMAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class TeamParticipationInIncidentController : Controller
{
    private readonly FireDbContex _context;

    public TeamParticipationInIncidentController(FireDbContex context)
    {
        _context = context;
    }

    // LIST
    public async Task<IActionResult> Index()
    {
        var data = _context.IncidentTeams
            .Include(t => t.Team)
            .Include(t => t.Incident);

        return View(await data.ToListAsync());
    }

    // DETAILS
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var item = await _context.IncidentTeams
            .Include(t => t.Team)
            .Include(t => t.Incident)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (item == null) return NotFound();

        return View(item);
    }

    // CREATE
    public IActionResult Create()
    {
        ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id");
        ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Id");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TeamParticipationInIncident item)
    {
        if (ModelState.IsValid)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", item.TeamId);
        ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Id", item.IncidentId);
        return View(item);
    }

    // EDIT
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var item = await _context.IncidentTeams.FindAsync(id);
        if (item == null) return NotFound();

        ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", item.TeamId);
        ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Id", item.IncidentId);

        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, TeamParticipationInIncident item)
    {
        if (id != item.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", item.TeamId);
        ViewData["IncidentId"] = new SelectList(_context.Incidents, "Id", "Id", item.IncidentId);

        return View(item);
    }

    // DELETE
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var item = await _context.IncidentTeams
            .Include(t => t.Team)
            .Include(t => t.Incident)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (item == null) return NotFound();

        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.IncidentTeams.FindAsync(id);
        _context.IncidentTeams.Remove(item);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}