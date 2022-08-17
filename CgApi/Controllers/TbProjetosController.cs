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
    public class TbProjetosController : ControllerBase
    {
        private readonly cursodev_grupo2Context _context;

        public TbProjetosController(cursodev_grupo2Context context)
        {
            _context = context;
        }

        // GET: api/TbProjetoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbProjeto>>> GetTbProjeto()
        {
          if (_context.TbProjeto == null)
          {
              return NotFound();
          }
            return await _context.TbProjeto.ToListAsync();
        }

        // GET: api/TbProjetoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbProjeto>> GetTbProjeto(int id)
        {
          if (_context.TbProjeto == null)
          {
              return NotFound();
          }
            var tbProjeto = await _context.TbProjeto.FindAsync(id);

            if (tbProjeto == null)
            {
                return NotFound();
            }

            return tbProjeto;
        }

        // PUT: api/TbProjetoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbProjeto(int id, TbProjeto tbProjeto)
        {
            if (id != tbProjeto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbProjeto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbProjetoExists(id))
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

        // POST: api/TbProjetoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbProjeto>> PostTbProjeto(TbProjeto tbProjeto)
        {
          if (_context.TbProjeto == null)
          {
              return Problem("Entity set 'cursodev_grupo2Context.TbProjeto'  is null.");
          }
            _context.TbProjeto.Add(tbProjeto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbProjetoExists(tbProjeto.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbProjeto", new { id = tbProjeto.Id }, tbProjeto);
        }

        // DELETE: api/TbProjetoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbProjeto(int id)
        {
            if (_context.TbProjeto == null)
            {
                return NotFound();
            }
            var tbProjeto = await _context.TbProjeto.FindAsync(id);
            if (tbProjeto == null)
            {
                return NotFound();
            }

            _context.TbProjeto.Remove(tbProjeto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbProjetoExists(int id)
        {
            return (_context.TbProjeto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
