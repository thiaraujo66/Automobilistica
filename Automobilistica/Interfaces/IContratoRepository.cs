using Automobilistica.Models;

namespace Automobilistica.Interfaces
{
    public interface IContratoRepository
    {
        void Incluir(Contrato contrato);
        void Alterar(Contrato contrato);
        void Excluir(Contrato contrato);
        Task<Contrato> GetById(int id);
        Task<IEnumerable<Contrato>> SelecionarTodos();

        Task<bool> SaveAllAsync();
    }
}
