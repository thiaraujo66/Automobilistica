using Automobilistica.Interfaces;
using Automobilistica.Models;
using Microsoft.EntityFrameworkCore;

namespace Automobilistica.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly AutomobilisticaContext _context;
        public ContratoRepository(AutomobilisticaContext context)
        {
            _context = context;
        }

        public void Alterar(Contrato contrato)
        {
            _context.Entry(contrato).State = EntityState.Modified;
        }

        public void Excluir(Contrato contrato)
        {
            _context.Contrato.Remove(contrato);
        }

        public async Task<Contrato> GetById(int id)
        {
            return await _context.Contrato.AsNoTracking().Where(e => e.Ctcdcontrato == id).FirstOrDefaultAsync();
        }

        public void Incluir(Contrato contrato)
        {
            _context.Contrato.Add(contrato);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Contrato>> SelecionarTodos()
        {
            return await _context.Contrato.ToListAsync();
        }
    }
}
