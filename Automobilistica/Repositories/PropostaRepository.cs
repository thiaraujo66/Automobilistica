using Automobilistica.Interfaces;
using Automobilistica.Models;
using Microsoft.EntityFrameworkCore;

namespace Automobilistica.Repositories
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly AutomobilisticaContext _context;
        public PropostaRepository(AutomobilisticaContext context)
        {
            _context = context;
        }

        public void Alterar(Proposta proposta)
        {
            _context.Entry(proposta).State = EntityState.Modified;
        }

        public void Excluir(Proposta proposta)
        {
            _context.Proposta.Remove(proposta);
        }

        public async Task<Proposta> GetById(int id)
        {
            return await _context.Proposta.AsNoTracking().Where(e => e.Ppcdproposta == id).FirstOrDefaultAsync();
        }

        public Proposta Incluir(Proposta proposta)
        {
            using (var context = _context)
            {
                _context.Proposta.Add(proposta);
                context.SaveChanges();
                return proposta;
            }

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Proposta>> SelecionarTodos()
        {
            return await _context.Proposta.ToListAsync();
        }
    }
}
