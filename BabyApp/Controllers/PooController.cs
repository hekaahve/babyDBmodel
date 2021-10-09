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
    public class PooController : ControllerBase
    {
        private readonly DataContext _context;

        public PooController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Poo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poo>>> GetPoos()
        {
            return await _context.Poos.ToListAsync();
        }

        // GET: api/Poo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poo>> GetPoo(int id)
        {
            var poo = await _context.Poos.FindAsync(id);

            if (poo == null)
            {
                return NotFound();
            }

            return poo;
        }

        // PUT: api/Poo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoo(int id, Poo poo)
        {
            if (id != poo.Id)
            {
                return BadRequest();
            }

            _context.Entry(poo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PooExists(id))
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

        // POST: api/Poo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Poo>> PostPoo(Poo poo)
        {
            _context.Poos.Add(poo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoo", new { id = poo.Id }, poo);
        }

        // DELETE: api/Poo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoo(int id)
        {
            var poo = await _context.Poos.FindAsync(id);
            if (poo == null)
            {
                return NotFound();
            }

            _context.Poos.Remove(poo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PooExists(int id)
        {
            return _context.Poos.Any(e => e.Id == id);
        }
    }
}
