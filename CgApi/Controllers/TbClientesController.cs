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
    public class TbClientesController : ControllerBase
    {
        private readonly cursodev_grupo2Context _context;

        public TbClientesController(cursodev_grupo2Context context)
        {
            _context = context;
        }

        // GET: api/TbClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCliente>>> GetTbCliente()
        {
          if (_context.TbCliente == null)
          {
              return NotFound();
          }
            return await _context.TbCliente.ToListAsync();
        }

        // GET: api/TbClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCliente>> GetTbCliente(int id)
        {
          if (_context.TbCliente == null)
          {
              return NotFound();
          }
            var tbCliente = await _context.TbCliente.FindAsync(id);

            if (tbCliente == null)
            {
                return NotFound();
            }

            return tbCliente;
        }

        // PUT: api/TbClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCliente(int id, TbCliente tbCliente)
        {
            if (id != tbCliente.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(tbCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbClienteExists(id))
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

        // POST: api/TbClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbCliente>> PostTbCliente(TbCliente tbCliente)
        {
          if (_context.TbCliente == null)
          {
              return Problem("Entity set 'cursodev_grupo2Context.TbCliente'  is null.");
          }
            _context.TbCliente.Add(tbCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbClienteExists(tbCliente.Cpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbCliente", new { id = tbCliente.Cpf }, tbCliente);
        }

        // DELETE: api/TbClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCliente(int id)
        {
            if (_context.TbCliente == null)
            {
                return NotFound();
            }
            var tbCliente = await _context.TbCliente.FindAsync(id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            _context.TbCliente.Remove(tbCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbClienteExists(int id)
        {
            return (_context.TbCliente?.Any(e => e.Cpf == id)).GetValueOrDefault();
        }
    }
}
