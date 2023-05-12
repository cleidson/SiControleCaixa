using SiControleCaixa.Infrastructure.Data.Models;

namespace SiControleCaixa.Infrastructure.Data.Repository.Interfaces
{
    public interface ITransacaoRepository
    {
        Task<bool> InsertTransacaoAsync(Transacao transacao);
        Task<List<Transacao>> GetConsolidadoDiarioAsync(DateTime? data);

    }
}