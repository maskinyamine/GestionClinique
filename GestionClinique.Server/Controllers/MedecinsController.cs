using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionClinique.Server.Data;
using GestionClinique.Shared.Models;

namespace GestionClinique.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedecinsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedecinsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medecin>>> GetMedecins()
        {
            return await _context.Medecins.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medecin>> GetMedecin(int id)
        {
            var medecin = await _context.Medecins.FindAsync(id);

            if (medecin == null)
            {
                return NotFound();
            }

            return medecin;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedecin(int id, Medecin medecin)
        {
            if (id != medecin.Id)
            {
                return BadRequest();
            }

            _context.Entry(medecin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedecinExists(id))
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
        public async Task<ActionResult<Medecin>> PostMedecin(Medecin medecin)
        {
            _context.Medecins.Add(medecin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedecin", new { id = medecin.Id }, medecin);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedecin(int id)
        {
            var medecin = await _context.Medecins.FindAsync(id);
            if (medecin == null)
            {
                return NotFound();
            }

            _context.Medecins.Remove(medecin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedecinExists(int id)
        {
            return _context.Medecins.Any(e => e.Id == id);
        }
    }
}
