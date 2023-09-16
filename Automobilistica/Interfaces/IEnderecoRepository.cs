using Automobilistica.Models;

namespace Automobilistica.Interfaces
{
    public interface IEnderecoRepository
    {
        Enderecos Incluir(Enderecos enderecos);
        void Alterar(Enderecos enderecos);
        void Excluir(Enderecos enderecos);
        Task<Enderecos> GetById(int id);
        Task<IEnumerable<Enderecos>> SelecionarTodos();

        Task<bool> SaveAllAsync();
    }
}
