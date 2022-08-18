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
    public class TbPaisesController : ControllerBase
    {
        private readonly cursodev_grupo2Context _context;

        public TbPaisesController(cursodev_grupo2Context context)
        {
            _context = context;
        }

        // GET: api/TbPaises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPais>>> GetTbPais()
        {
          if (_context.TbPais == null)
          {
              return NotFound();
          }
            return await _context.TbPais.ToListAsync();
        }

        // GET: api/TbPaises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPais>> GetTbPais(int id)
        {
          if (_context.TbPais == null)
          {
              return NotFound();
          }
            var tbPais = await _context.TbPais.FindAsync(id);

            if (tbPais == null)
            {
                return NotFound();
            }

            return tbPais;
        }

        // PUT: api/TbPaises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPais(int id, TbPais tbPais)
        {
            if (id != tbPais.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbPais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPaisExists(id))
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

        // POST: api/TbPaises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPais>> PostTbPais(TbPais tbPais)
        {
          if (_context.TbPais == null)
          {
              return Problem("Entity set 'cursodev_grupo2Context.TbPais'  is null.");
          }
            _context.TbPais.Add(tbPais);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbPaisExists(tbPais.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbPais", new { id = tbPais.Id }, tbPais);
        }

        // DELETE: api/TbPaises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPais(int id)
        {
            if (_context.TbPais == null)
            {
                return NotFound();
            }
            var tbPais = await _context.TbPais.FindAsync(id);
            if (tbPais == null)
            {
                return NotFound();
            }

            _context.TbPais.Remove(tbPais);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPaisExists(int id)
        {
            return (_context.TbPais?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
