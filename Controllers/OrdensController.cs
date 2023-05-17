using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvestApi.Models;

namespace InvestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdensController : ControllerBase
    {
        private readonly InvestApiContext _context;

        public OrdensController(InvestApiContext context)
        {
            _context = context;
        }

        // GET: api/Ordens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordem>>> GetOrdem()
        {
          if (_context.Ordem == null)
          {
              return NotFound();
          }
            return await _context.Ordem.ToListAsync();
        }

        // GET: api/Ordens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordem>> GetOrdem(int id)
        {
          if (_context.Ordem == null)
          {
              return NotFound();
          }
            var ordem = await _context.Ordem.FindAsync(id);

            if (ordem == null)
            {
                return NotFound();
            }

            return ordem;
        }

        // PUT: api/Ordens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdem(int id, Ordem ordem)
        {
            if (id != ordem.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdemExists(id))
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

        // POST: api/Ordens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordem>> PostOrdem(Ordem ordem)
        {
          if (_context.Ordem == null)
          {
              return Problem("Entity set 'InvestApiContext.Ordem'  is null.");
          }
            _context.Ordem.Add(ordem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrdem), new { id = ordem.Id }, ordem);
        }

        // DELETE: api/Ordens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdem(int id)
        {
            if (_context.Ordem == null)
            {
                return NotFound();
            }
            var ordem = await _context.Ordem.FindAsync(id);
            if (ordem == null)
            {
                return NotFound();
            }

            _context.Ordem.Remove(ordem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdemExists(int id)
        {
            return (_context.Ordem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
