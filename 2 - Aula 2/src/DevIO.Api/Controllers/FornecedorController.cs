using DevIO.Business.DataTransferObjects;
using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [Route("api/fornecedores")]
    [ApiController]
    public class FornecedorController : BaseApiController
    {
        private readonly IFornecedorService _services;

        public FornecedorController(IFornecedorService services) =>
            _services = services;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorDTO>>> ObterTodosAsync()
        {
            return Ok(await _services.ObterTodosAsync());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<FornecedorDTO>> ObterPorIdAsync(Guid id)
        {
            var fornecedor = await _services.ObterPorIdAsync(id);

            if (fornecedor == null)
                return NotFound(new
                {
                    Sucess = false,
                    Notification = "Fornecedor não encontrato."
                });

            return Ok(new
            {
                Sucess = true,
                Data = fornecedor
            });
        }
    }
}
