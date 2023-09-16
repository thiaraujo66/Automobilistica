using Automobilistica.Interfaces;
using Automobilistica.Models;
using Microsoft.EntityFrameworkCore;

namespace Automobilistica.Repositories
{
    public class CarroClienteRepository : ICarroClienteRepository
    {
        private readonly AutomobilisticaContext _context;

        public CarroClienteRepository(AutomobilisticaContext context)
        {
            _context = context;
        }

        public void Alterar(CarroCliente carroClientes)
        {
            _context.Entry(carroClientes).State = EntityState.Modified;
        }

        public void Excluir(CarroCliente carroClientes)
        {
            _context.CarroCliente.Remove(carroClientes);
        }

        public async Task<CarroCliente> GetByCarroCliente(int idCarro, int idCliente)
        {
            return await _context.CarroCliente.AsNoTracking().Where(e => e.Cccdcarro == idCarro && e.Cccdcliente == idCliente).FirstOrDefaultAsync();
        }

        public async Task<List<CarroCliente>> GetByCliente(int idCliente)
        {
            return await _context.CarroCliente.AsNoTracking().Where(e => e.Cccdcliente == idCliente).ToListAsync();
        }

        public void Incluir(List<CarroCliente> carroClientes)
        {
            _context.CarroCliente.AddRange(carroClientes);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CarroCliente>> SelecionarTodos()
        {
            return await _context.CarroCliente.ToListAsync();
        }
    }
}
