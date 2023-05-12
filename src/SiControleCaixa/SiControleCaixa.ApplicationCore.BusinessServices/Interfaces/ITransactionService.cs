using SiControleCaixa.ApplicationCore.DTO.Transacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.ApplicationCore.BusinessServices.Interfaces
{
    public interface ITransactionService
    {

        Task<bool> SetTransacaoFluxoCaixa(TransacaoDto transacao);

        Task<FluxoCaixaConsolidadoDto> GetConsolidadoDiario(string data);
    }
}
