using FIREMAN.Data;
using FIREMAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ReportsController : Controller
{
    private readonly FireDbContext _context;

    public ReportsController(FireDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> EmployeeIncidentRanking()
    {
        int lastYear = DateTime.Now.Year - 1;

        var ranking = await _context.IncidentTeams
            .Include(t => t.Incident)
            .Where(t => t.Incident.Date.Year == lastYear)
            .SelectMany(t => _context.Employees.Where(e => e.TeamId == t.TeamId))
            .GroupBy(e => new { e.EmployeeId, e.Name })
            .Select(g => new EmployeeIncidentRankingViewModel
            {
                EmployeeId = g.Key.EmployeeId,
                EmployeeName = g.Key.Name,
                IncidentCount = g.Count()
            })
            .OrderByDescending(x => x.IncidentCount)
            .ToListAsync();

        return View(ranking);
    }
}
