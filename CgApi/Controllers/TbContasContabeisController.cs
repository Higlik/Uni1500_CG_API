using CgApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CgApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContasContabeisController : ControllerBase
    {
        private readonly IContasContabeis _repository;

        public ContasContabeisController(IContasContabeis repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateConta([FromBody] CreateNewContaContabeis conta)
        {
            try
            {
                await _repository.CreateConta(conta);
                return Created("api/[controller]", conta);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllContas()
        {
            try
            {
                return Ok(await _repository.GetAllContas());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}