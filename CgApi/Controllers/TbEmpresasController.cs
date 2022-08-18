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
    public class TbEmpresasController : ControllerBase
    {
        private readonly cursodev_grupo2Context _context;

        public TbEmpresasController(cursodev_grupo2Context context)
        {
            _context = context;
        }

        // GET: api/TbEmpresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbEmpresa>>> GetTbEmpresa()
        {
          if (_context.TbEmpresa == null)
          {
              return NotFound();
          }
            return await _context.TbEmpresa.ToListAsync();
        }

        // GET: api/TbEmpresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbEmpresa>> GetTbEmpresa(int id)
        {
          if (_context.TbEmpresa == null)
          {
              return NotFound();
          }
            var tbEmpresa = await _context.TbEmpresa.FindAsync(id);

            if (tbEmpresa == null)
            {
                return NotFound();
            }

            return tbEmpresa;
        }

        // PUT: api/TbEmpresas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbEmpresa(int id, TbEmpresa tbEmpresa)
        {
            if (id != tbEmpresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbEmpresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbEmpresaExists(id))
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

        // POST: api/TbEmpresas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbEmpresa>> PostTbEmpresa(TbEmpresa tbEmpresa)
        {
          if (_context.TbEmpresa == null)
          {
              return Problem("Entity set 'cursodev_grupo2Context.TbEmpresa'  is null.");
          }
            _context.TbEmpresa.Add(tbEmpresa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbEmpresaExists(tbEmpresa.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbEmpresa", new { id = tbEmpresa.Id }, tbEmpresa);
        }

        // DELETE: api/TbEmpresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbEmpresa(int id)
        {
            if (_context.TbEmpresa == null)
            {
                return NotFound();
            }
            var tbEmpresa = await _context.TbEmpresa.FindAsync(id);
            if (tbEmpresa == null)
            {
                return NotFound();
            }

            _context.TbEmpresa.Remove(tbEmpresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbEmpresaExists(int id)
        {
            return (_context.TbEmpresa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
