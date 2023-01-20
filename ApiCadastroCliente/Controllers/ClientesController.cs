using ApiCadastroCliente.Models;
using ApiCadastroCliente.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCadastroCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        //Endpoints

        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetCliente()
        {
            return await _clienteRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            return await _clienteRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] Cliente cliente)
        {
            var newCliente = await _clienteRepository.Create(cliente);
            return CreatedAtAction(nameof(GetCliente),new { id = newCliente.Id}, newCliente);
        }
        [HttpPut]
        public async Task<ActionResult<Cliente>> PutCliente(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id) BadRequest(nameof(Cliente));
            await _clienteRepository.Update(cliente);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var toDelete = await _clienteRepository.Get(id);
            if (toDelete == null) NotFound();
            await _clienteRepository.Delete(toDelete.Id);
            return NoContent();
        }

    }
}
