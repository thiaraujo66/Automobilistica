using Automobilistica.Interfaces;
using Automobilistica.Models;
using Microsoft.EntityFrameworkCore;

namespace Automobilistica.Repositories
{
    public class PessoasRepository : IPessoasRepository
    {
        private readonly AutomobilisticaContext _context;

        public PessoasRepository(AutomobilisticaContext context)
        {
            _context = context;
        }

        public void Alterar(Pessoas pessoas)
        {
            _context.Entry(pessoas).State = EntityState.Modified;
        }

        public void Excluir(Pessoas pessoas)
        {
            _context.Pessoas.Remove(pessoas);
        }

        public async Task<Pessoas> GetById(int id)
        {
            return await _context.Pessoas.AsNoTracking().Where(e => e.Pscdpessoa == id).FirstOrDefaultAsync();
        }

        public Pessoas Incluir(Pessoas pessoas)
        {
            using (var context = _context)
            {
                _context.Pessoas.Add(pessoas);
                context.SaveChanges();
                return pessoas;
            }
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Pessoas>> SelecionarTodos()
        {
            return await _context.Pessoas.ToListAsync();
        }
    }
}
