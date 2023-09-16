using Automobilistica.Models;

namespace Automobilistica.Interfaces
{
    public interface IClienteRepository
    {
        void Incluir(Cliente cliente);
        void Alterar(Cliente cliente);
        void Excluir(Cliente cliente);
        Task<Cliente> GetById(int id);
        Task<IEnumerable<Cliente>> SelecionarTodos();

        Task<bool> SaveAllAsync();
    }
}
