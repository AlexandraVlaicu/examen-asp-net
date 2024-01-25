
using examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using examen.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
public class EvenimenteController : Controller
{
    private readonly ApplicationDbContext _context;

    public EvenimenteController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Eveniment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Evenimente>>> GetEv()
    {
        return await _context.Ev.ToListAsync();
    }

    public ActionResult<IEnumerable<Evenimente>> GetEventsWithParticipants()
    {
        var evenimenteSiParticipanti = _context.Ev
            .Include(e => e.P) // Asigurați-vă că ați definit relația în model (proprietatea Participanti)
            .ToList();

        return evenimenteSiParticipanti;
    }
    // GET: api/Eveniment/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Evenimente>> GetEv(int id)
    {
        var client = await _context.Ev.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }
    public IActionResult Index()
    {
        var evenimente = _context.Ev.ToList();

        return View("~/Views/View1.cshtml", evenimente);
    }

    // POST: api/Eveniment
    [HttpPost]
    public async Task<ActionResult<Evenimente>> PostClient(Evenimente ev)
    {
        _context.Ev.Add(ev);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEv), new { id = ev.idev }, ev);
    }

}


