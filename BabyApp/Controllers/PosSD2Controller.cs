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
    public class PosSD2Controller : ControllerBase
    {
        private readonly DataContext _context;

        public PosSD2Controller(DataContext context)
        {
            _context = context;
        }

        // GET: api/PosSD2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PosSD2>>> GetposSD2s()
        {
            return await _context.posSD2s.ToListAsync();
        }

        // GET: api/PosSD2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PosSD2>> GetPosSD2(int id)
        {
            var posSD2 = await _context.posSD2s.FindAsync(id);

            if (posSD2 == null)
            {
                return NotFound();
            }

            return posSD2;
        }

        // PUT: api/PosSD2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosSD2(int id, PosSD2 posSD2)
        {
            if (id != posSD2.Id)
            {
                return BadRequest();
            }

            _context.Entry(posSD2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosSD2Exists(id))
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

        // POST: api/PosSD2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PosSD2>> PostPosSD2(PosSD2 posSD2)
        {
            _context.posSD2s.Add(posSD2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosSD2", new { id = posSD2.Id }, posSD2);
        }

        // DELETE: api/PosSD2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosSD2(int id)
        {
            var posSD2 = await _context.posSD2s.FindAsync(id);
            if (posSD2 == null)
            {
                return NotFound();
            }

            _context.posSD2s.Remove(posSD2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PosSD2Exists(int id)
        {
            return _context.posSD2s.Any(e => e.Id == id);
        }
    }
}
