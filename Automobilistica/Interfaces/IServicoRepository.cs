using Automobilistica.Models;

namespace Automobilistica.Interfaces
{
    public interface IServicoRepository
    {
        void Incluir(Servicos servico);
        void Alterar(Servicos servico);
        void Excluir(Servicos servico);
        Task<Servicos> GetById(int id);
        Task<IEnumerable<Servicos>> SelecionarTodos();

        Task<bool> SaveAllAsync();
    }
}
