using Automobilistica.Models;

namespace Automobilistica.Interfaces
{
    public interface ICarroClienteRepository
    {
        void Incluir(List<CarroCliente> carroClientes);
        void Alterar(CarroCliente carroClientes);
        void Excluir(CarroCliente carroClientes);
        Task<List<CarroCliente>> GetByCliente(int idCliente);
        Task<CarroCliente> GetByCarroCliente(int idCarro, int idCliente);

        Task<IEnumerable<CarroCliente>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}
