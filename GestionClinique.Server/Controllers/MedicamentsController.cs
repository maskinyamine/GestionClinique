using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionClinique.Server.Data;
using GestionClinique.Shared.Models;

namespace GestionClinique.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicamentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicament>>> GetMedicaments()
        {
            return await _context.Medicaments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medicament>> GetMedicament(int id)
        {
            var medicament = await _context.Medicaments.FindAsync(id);

            if (medicament == null)
            {
                return NotFound();
            }

            return medicament;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicament(int id, Medicament medicament)
        {
            if (id != medicament.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentExists(id))
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
        public async Task<ActionResult<Medicament>> PostMedicament(Medicament medicament)
        {
            _context.Medicaments.Add(medicament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicament", new { id = medicament.Id }, medicament);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicament(int id)
        {
            var medicament = await _context.Medicaments.FindAsync(id);
            if (medicament == null)
            {
                return NotFound();
            }

            _context.Medicaments.Remove(medicament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicamentExists(int id)
        {
            return _context.Medicaments.Any(e => e.Id == id);
        }
    }
}
