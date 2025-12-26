using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionClinique.Server.Data;
using GestionClinique.Shared.Models;

namespace GestionClinique.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendezVousController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RendezVousController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RendezVous>>> GetRendezVous()
        {
            return await _context.RendezVous
                .Include(r => r.Patient)
                .Include(r => r.Medecin)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RendezVous>> GetRendezVous(int id)
        {
            var rendezVous = await _context.RendezVous
                .Include(r => r.Patient)
                .Include(r => r.Medecin)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rendezVous == null)
            {
                return NotFound();
            }

            return rendezVous;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRendezVous(int id, RendezVous rendezVous)
        {
            if (id != rendezVous.Id)
            {
                return BadRequest();
            }

            _context.Entry(rendezVous).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RendezVousExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<RendezVous>> PostRendezVous(RendezVous rendezVous)
        {
            // Note: EF Core might try to add Patient/Medecin if attached. 
            // Better to rely on FKs (PatientId, MedecinId) and set nav props to null if coming from client.
            // For simplicity we assume client sends valid IDs.
            
            _context.RendezVous.Add(rendezVous);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRendezVous", new { id = rendezVous.Id }, rendezVous);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRendezVous(int id)
        {
            var rendezVous = await _context.RendezVous.FindAsync(id);
            if (rendezVous == null)
            {
                return NotFound();
            }

            _context.RendezVous.Remove(rendezVous);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RendezVousExists(int id)
        {
            return _context.RendezVous.Any(e => e.Id == id);
        }
    }
}
