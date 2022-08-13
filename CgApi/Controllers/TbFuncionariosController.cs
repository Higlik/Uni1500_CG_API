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
    public class TbFuncionariosController : ControllerBase
    {
        private readonly cursodev_grupo2Context _context;

        public TbFuncionariosController(cursodev_grupo2Context context)
        {
            _context = context;
        }

        // GET: api/TbFuncionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbFuncionario>>> GetTbFuncionario()
        {
            if (_context.TbFuncionario == null)
            {
                return NotFound();
            }
            return await _context.TbFuncionario.ToListAsync();
        }

        // GET: api/TbFuncionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbFuncionario>> GetTbFuncionario(int id)
        {
            if (_context.TbFuncionario == null)
            {
                return NotFound();
            }
            var tbFuncionario = await _context.TbFuncionario.FindAsync(id);

            if (tbFuncionario == null)
            {
                return NotFound();
            }

            return tbFuncionario;
        }

        // PUT: api/TbFuncionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbFuncionario(int id, TbFuncionario tbFuncionario)
        {
            if (id != tbFuncionario.Matricula)
            {
                return BadRequest();
            }

            _context.Entry(tbFuncionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbFuncionarioExists(id))
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

        // POST: api/TbFuncionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbFuncionario>> PostTbFuncionario(TbFuncionario tbFuncionario)
        {
            if (_context.TbFuncionario == null)
            {
                return Problem("Entity set 'cursodev_grupo2Context.TbFuncionario'  is null.");
            }
            _context.TbFuncionario.Add(tbFuncionario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbFuncionarioExists(tbFuncionario.Matricula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbFuncionario", new { id = tbFuncionario.Matricula }, tbFuncionario);
        }

        // DELETE: api/TbFuncionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbFuncionario(int id)
        {
            if (_context.TbFuncionario == null)
            {
                return NotFound();
            }
            var tbFuncionario = await _context.TbFuncionario.FindAsync(id);
            if (tbFuncionario == null)
            {
                return NotFound();
            }

            _context.TbFuncionario.Remove(tbFuncionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbFuncionarioExists(int id)
        {
            return (_context.TbFuncionario?.Any(e => e.Matricula == id)).GetValueOrDefault();
        }
    }
}
