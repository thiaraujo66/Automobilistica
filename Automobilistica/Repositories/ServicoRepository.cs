using Automobilistica.Interfaces;
using Automobilistica.Models;
using Microsoft.EntityFrameworkCore;

namespace Automobilistica.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly AutomobilisticaContext _context;

        public ServicoRepository(AutomobilisticaContext context) 
        {
            _context = context;
        }

        public void Alterar(Servicos servico)
        {
            _context.Entry(servico).State = EntityState.Modified;
        }

        public void Excluir(Servicos servico)
        {
            _context.Servicos.Remove(servico);
        }

        public async Task<Servicos> GetById(int id)
        {
            return await _context.Servicos.AsNoTracking().Where(e => e.Srcdservico == id).FirstOrDefaultAsync();
        }

        public void Incluir(Servicos servico)
        {
            _context.Servicos.Add(servico);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Servicos>> SelecionarTodos()
        {
            return await _context.Servicos.ToListAsync();
        }
    }
}
