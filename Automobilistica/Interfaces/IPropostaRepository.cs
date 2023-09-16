using Automobilistica.Models;

namespace Automobilistica.Interfaces
{
    public interface IPropostaRepository
    {
        Proposta Incluir(Proposta proposta);
        void Alterar(Proposta proposta);
        void Excluir(Proposta proposta);
        Task<Proposta> GetById(int id);
        Task<IEnumerable<Proposta>> SelecionarTodos();

        Task<bool> SaveAllAsync();
    }
}
