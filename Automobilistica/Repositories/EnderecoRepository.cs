using Automobilistica.Interfaces;
using Automobilistica.Models;
using Microsoft.EntityFrameworkCore;

namespace Automobilistica.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AutomobilisticaContext _context;

        public EnderecoRepository(AutomobilisticaContext context)
        {
            _context = context;
        }

        public void Alterar(Enderecos enderecos)
        {
            _context.Entry(enderecos).State = EntityState.Modified;
        }

        public void Excluir(Enderecos enderecos)
        {
            _context.Enderecos.Remove(enderecos);
        }

        public async Task<Enderecos> GetById(int id)
        {
            return await _context.Enderecos.AsNoTracking().Where(e => e.Edcdendereco == id).FirstOrDefaultAsync();
        }

        public Enderecos Incluir(Enderecos enderecos)
        {
            using (var context = _context)
            {
                _context.Enderecos.Add(enderecos);
                context.SaveChanges();
                return enderecos;
            }
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Enderecos>> SelecionarTodos()
        {
            return await _context.Enderecos.ToListAsync();
        }
    }
}
