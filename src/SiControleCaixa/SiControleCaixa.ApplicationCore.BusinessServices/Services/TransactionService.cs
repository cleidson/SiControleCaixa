using SiControleCaixa.ApplicationCore.BusinessServices.Interfaces;
using SiControleCaixa.ApplicationCore.DTO.Transacao;
using SiControleCaixa.Infrastructure.Data.Models;
using SiControleCaixa.Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.ApplicationCore.BusinessServices.Services
{
    public class TransactionService : ITransactionService
    {
        protected ITransacaoRepository _transacaoRepository;
        public TransactionService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }


        public async Task<FluxoCaixaConsolidadoDto> GetConsolidadoDiario(string data)
        { 
            var dbResult = await _transacaoRepository.GetConsolidadoDiarioAsync(DateTime.Parse(data));
            var TotalCredito = dbResult.Where(t => t.TipoTransacao == 1).Sum(t => t.Valor);
            var TotalDebito = dbResult.Where(t => t.TipoTransacao == 0).Sum(t => t.Valor);

            return  new FluxoCaixaConsolidadoDto
            {
                Data = data,
                TotalSaidas = (double?)TotalDebito,
                TotalEntradas = (double?)TotalCredito,
                TotalConsolidado = (double?)(TotalCredito - TotalDebito)
            };
        }

         
        public async Task<bool> SetTransacaoFluxoCaixa(TransacaoDto transacao)
        {
            if (transacao == null)
                throw new ArgumentNullException("O objeto transacao não pode ser null");

            if(transacao.DataTransacao == null)
                throw new ArgumentNullException("A data do objeto transacao não pode ser null");

            return await _transacaoRepository.InsertTransacaoAsync(new Transacao
            {
                DataTransacao = DateTime.Parse(transacao.DataTransacao),
                TipoTransacao = transacao.TipoTransacao,
                Valor = transacao.Valor
            });
        }
    }
}
