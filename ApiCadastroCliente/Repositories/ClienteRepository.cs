using ApiCadastroCliente.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCadastroCliente.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _context;

        public ClienteRepository(ClienteContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente cliente) // Cria novo 
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> Get() // Busca todos
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Cliente> Get(int id) // Busca por id
        {
            return await _context.Clientes.FindAsync(id);
        }
        public async Task Update(Cliente cliente) // Atualiza
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id) // Apaga por id
        {
            var toDelete = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(toDelete);
            await _context.SaveChangesAsync();
        }
    }
}
