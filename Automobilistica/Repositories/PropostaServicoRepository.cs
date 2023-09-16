using Automobilistica.Interfaces;
using Automobilistica.Models;
using Microsoft.EntityFrameworkCore;

namespace Automobilistica.Repositories
{
    public class PropostaServicoRepository : IPropostaServicoRepository
    {
        private readonly AutomobilisticaContext _context;

        public PropostaServicoRepository(AutomobilisticaContext context)
        {
            _context = context;
        }

        public void Alterar(PropostaServico propostaServico)
        {
            _context.Entry(propostaServico).State = EntityState.Modified;
        }

        public void Excluir(PropostaServico propostaServico)
        {
            _context.PropostaServico.Remove(propostaServico);
        }

        public async Task<List<PropostaServico>> GetByProposta(int idProp)
        {
            return await _context.PropostaServico.AsNoTracking().Where(e => e.Prcdproposta == idProp).ToListAsync();
        }

        public async Task<PropostaServico> GetByPropostaService(int idProp, int idServ)
        {
            return await _context.PropostaServico.AsNoTracking().Where(e => e.Prcdproposta == idProp && e.Prcdservico == idServ).FirstOrDefaultAsync();
        }

        public void Incluir(List<PropostaServico> propostaServico)
        {
            _context.PropostaServico.AddRange(propostaServico);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PropostaServico>> SelecionarTodos()
        {
            return await _context.PropostaServico.ToListAsync();
        }
    }
}
