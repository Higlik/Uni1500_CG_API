using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExemploEntityFramework;
using CgApi;

namespace ExemploEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbBancosController : ControllerBase
    {
        private readonly cursodev_grupo2Context _context;

        public TbBancosController(cursodev_grupo2Context context)
        {
            _context = context;
        }

        // GET: api/TbBancos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbBanco>>> GetTbBanco()
        {
            if (_context.TbBanco == null)
            {
                return NotFound();
            }
            return await _context.TbBanco.ToListAsync();
        }

        // GET: api/TbBancos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbBanco>> GetTbBanco(int id)
        {
            if (_context.TbBanco == null)
            {
                return NotFound();
            }
            var tbBanco = await _context.TbBanco.FindAsync(id);

            if (tbBanco == null)
            {
                return NotFound();
            }

            return tbBanco;
        }

        // PUT: api/TbBancos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbBanco(int id, TbBanco tbBanco)
        {
            if (id != tbBanco.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbBanco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbBancoExists(id))
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

        // POST: api/TbBancos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbBanco>> PostTbBanco(TbBanco tbBanco)
        {
            if (_context.TbBanco == null)
            {
                return Problem("Entity set 'cursodev_grupo2Context.TbBanco'  is null.");
            }
            _context.TbBanco.Add(tbBanco);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbBancoExists(tbBanco.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbBanco", new { id = tbBanco.Id }, tbBanco);
        }

        // DELETE: api/TbBancos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbBanco(int id)
        {
            if (_context.TbBanco == null)
            {
                return NotFound();
            }
            var tbBanco = await _context.TbBanco.FindAsync(id);
            if (tbBanco == null)
            {
                return NotFound();
            }

            _context.TbBanco.Remove(tbBanco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbBancoExists(int id)
        {
            return (_context.TbBanco?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
