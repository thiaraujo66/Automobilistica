using Automobilistica.Models;

namespace Automobilistica.Interfaces
{
    public interface IPessoasRepository
    {
        Pessoas Incluir(Pessoas pessoas);
        void Alterar(Pessoas pessoas);
        void Excluir(Pessoas pessoas);
        Task<Pessoas> GetById(int id);
        Task<IEnumerable<Pessoas>> SelecionarTodos();

        Task<bool> SaveAllAsync();
    }
}
