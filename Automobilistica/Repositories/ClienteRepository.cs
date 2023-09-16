using Automobilistica.Interfaces;
using Automobilistica.Models;
using Microsoft.EntityFrameworkCore;

namespace Automobilistica.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AutomobilisticaContext _context;

        public ClienteRepository(AutomobilisticaContext context)
        {
            _context = context;
        }

        public void Alterar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }

        public void Excluir(Cliente cliente)
        {
            _context.Cliente.Remove(cliente);
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Cliente.AsNoTracking().Where(e => e.Clcdcliente == id).FirstOrDefaultAsync();
        }

        public void Incluir(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Cliente>> SelecionarTodos()
        {
            return await _context.Cliente.ToListAsync();
        }
    }
}
