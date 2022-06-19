using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DinnerAidAPI.Data;
using DinnerAidAPI.Models;

namespace DinnerAidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepiesController : ControllerBase
    {
        private readonly APIContext _context;

        public RecepiesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Recepies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recepie>>> GetRecepies()
        {
          if (_context.Recepies == null)
          {
              return NotFound();
          }
            return await _context.Recepies.ToListAsync();
        }

        // GET: api/Recepies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recepie>> GetRecepie(int id)
        {
          if (_context.Recepies == null)
          {
              return NotFound();
          }
            var recepie = await _context.Recepies.FindAsync(id);

            if (recepie == null)
            {
                return NotFound();
            }

            return recepie;
        }

        // PUT: api/Recepies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepie(int id, Recepie recepie)
        {
            if (id != recepie.Id)
            {
                return BadRequest();
            }

            _context.Entry(recepie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecepieExists(id))
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

        // POST: api/Recepies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recepie>> PostRecepie(Recepie recepie)
        {
          if (_context.Recepies == null)
          {
              return Problem("Entity set 'APIContext.Recepies'  is null.");
          }
            _context.Recepies.Add(recepie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecepie", new { id = recepie.Id }, recepie);
        }

        // DELETE: api/Recepies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecepie(int id)
        {
            if (_context.Recepies == null)
            {
                return NotFound();
            }
            var recepie = await _context.Recepies.FindAsync(id);
            if (recepie == null)
            {
                return NotFound();
            }

            _context.Recepies.Remove(recepie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecepieExists(int id)
        {
            return (_context.Recepies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
