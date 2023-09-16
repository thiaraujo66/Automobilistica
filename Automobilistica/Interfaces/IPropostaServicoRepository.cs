using Automobilistica.Models;

namespace Automobilistica.Interfaces
{
    public interface IPropostaServicoRepository
    {
        void Incluir(List<PropostaServico> propostaServico);
        void Alterar(PropostaServico propostaServico);
        void Excluir(PropostaServico propostaServico);
        Task<List<PropostaServico>> GetByProposta(int idProp);
        Task<PropostaServico> GetByPropostaService(int idProp, int idServ);

        Task<IEnumerable<PropostaServico>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}
