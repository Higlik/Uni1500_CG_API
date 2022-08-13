using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CgApi;

namespace CgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbMoedasController : ControllerBase
    {
        private readonly cursodev_grupo2Context _context;

        public TbMoedasController(cursodev_grupo2Context context)
        {
            _context = context;
        }

        // GET: api/TbMoedas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbMoeda>>> GetTbMoeda()
        {
          if (_context.TbMoeda == null)
          {
              return NotFound();
          }
            return await _context.TbMoeda.ToListAsync();
        }

        // GET: api/TbMoedas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbMoeda>> GetTbMoeda(int id)
        {
          if (_context.TbMoeda == null)
          {
              return NotFound();
          }
            var tbMoeda = await _context.TbMoeda.FindAsync(id);

            if (tbMoeda == null)
            {
                return NotFound();
            }

            return tbMoeda;
        }

        // PUT: api/TbMoedas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbMoeda(int id, TbMoeda tbMoeda)
        {
            if (id != tbMoeda.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbMoeda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbMoedaExists(id))
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

        // POST: api/TbMoedas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbMoeda>> PostTbMoeda(TbMoeda tbMoeda)
        {
          if (_context.TbMoeda == null)
          {
              return Problem("Entity set 'cursodev_grupo2Context.TbMoeda'  is null.");
          }
            _context.TbMoeda.Add(tbMoeda);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbMoedaExists(tbMoeda.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbMoeda", new { id = tbMoeda.Id }, tbMoeda);
        }

        // DELETE: api/TbMoedas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbMoeda(int id)
        {
            if (_context.TbMoeda == null)
            {
                return NotFound();
            }
            var tbMoeda = await _context.TbMoeda.FindAsync(id);
            if (tbMoeda == null)
            {
                return NotFound();
            }

            _context.TbMoeda.Remove(tbMoeda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbMoedaExists(int id)
        {
            return (_context.TbMoeda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
