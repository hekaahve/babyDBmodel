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
    public class NinniController : ControllerBase
    {
        private readonly DataContext _context;

        public NinniController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Ninni
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ninni>>> Getninnis()
        {
            return await _context.ninnis.ToListAsync();
        }

        // GET: api/Ninni/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ninni>> GetNinni(int id)
        {
            var ninni = await _context.ninnis.FindAsync(id);

            if (ninni == null)
            {
                return NotFound();
            }

            return ninni;
        }

        // PUT: api/Ninni/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNinni(int id, Ninni ninni)
        {
            if (id != ninni.Id)
            {
                return BadRequest();
            }

            _context.Entry(ninni).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NinniExists(id))
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

        // POST: api/Ninni
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ninni>> PostNinni(Ninni ninni)
        {
            _context.ninnis.Add(ninni);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNinni", new { id = ninni.Id }, ninni);
        }

        // DELETE: api/Ninni/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNinni(int id)
        {
            var ninni = await _context.ninnis.FindAsync(id);
            if (ninni == null)
            {
                return NotFound();
            }

            _context.ninnis.Remove(ninni);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NinniExists(int id)
        {
            return _context.ninnis.Any(e => e.Id == id);
        }
    }
}
