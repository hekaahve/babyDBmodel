using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BabyApp;
using BabyApp.Models;

namespace BabyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeeController : ControllerBase
    {
        private readonly DataContext _context;

        public PeeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Pee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pee>>> GetPees()
        {
            return await _context.Pees.ToListAsync();
        }

        // GET: api/Pee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pee>> GetPee(int id)
        {
            var pee = await _context.Pees.FindAsync(id);

            if (pee == null)
            {
                return NotFound();
            }

            return pee;
        }

        // PUT: api/Pee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPee(int id, Pee pee)
        {
            if (id != pee.Id)
            {
                return BadRequest();
            }

            _context.Entry(pee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeeExists(id))
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

        // POST: api/Pee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pee>> PostPee(Pee pee)
        {
            _context.Pees.Add(pee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPee", new { id = pee.Id }, pee);
        }

        // DELETE: api/Pee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePee(int id)
        {
            var pee = await _context.Pees.FindAsync(id);
            if (pee == null)
            {
                return NotFound();
            }

            _context.Pees.Remove(pee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeeExists(int id)
        {
            return _context.Pees.Any(e => e.Id == id);
        }
    }
}
