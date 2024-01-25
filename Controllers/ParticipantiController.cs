
using examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using examen.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

[Route("api/[controller]")]
[ApiController]
public class ParticipantiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ParticipantiController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Paricipant
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Participanti>>> GetP()
    {
        return await _context.P.ToListAsync();
    }

    // GET: api/Participant/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Participanti>> GetP(int id)
    {
        var client = await _context.P.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

    // POST: api/Participant
    [HttpPost]
    public async Task<ActionResult<Participanti>> PostP(Participanti p)
    {
       _context.P.Add(p);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetP), new { id = p.idpart }, p);
    }

}

