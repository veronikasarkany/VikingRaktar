using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VikingRaktar.Data;
using VikingRaktar.Models;

namespace VikingRaktar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Arus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aru>>> GetAru()
        {
            return await _context.Aru.ToListAsync();
        }

        // GET: api/Arus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aru>> GetAru(int id)
        {
            var aru = await _context.Aru.FindAsync(id);

            if (aru == null)
            {
                return NotFound();
            }

            return aru;
        }

        // PUT: api/Arus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAru(int id, Aru aru)
        {
            if (id != aru.Id)
            {
                return BadRequest();
            }

            _context.Entry(aru).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AruExists(id))
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

        // POST: api/Arus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aru>> PostAru(Aru aru)
        {
            _context.Aru.Add(aru);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAru", new { id = aru.Id }, aru);
        }

        // DELETE: api/Arus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAru(int id)
        {
            var aru = await _context.Aru.FindAsync(id);
            if (aru == null)
            {
                return NotFound();
            }

            _context.Aru.Remove(aru);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AruExists(int id)
        {
            return _context.Aru.Any(e => e.Id == id);
        }
    }
}
