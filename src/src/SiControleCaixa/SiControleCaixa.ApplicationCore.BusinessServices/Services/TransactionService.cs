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
    /// <summary>
    ///  Foi aplicado junto a implementação os seguintes princípios:
    ///  Single Responsibility Principle (SRP): onde a TransactionService 
    ///  única responsabilidade principal, que é fornecer serviços relacionados a transações de fluxo de caixa
    ///  Open/Closed Principle (OCP): onde a propria classe está fechada a modificações,podendo ser somente alterado algo (OPEN) através da criação de novos métodos onde não permite modificiação do comportamento.
    ///  E por fim Dependency Inversion Principle (DIP), onde aplico Injeção de depêndencia em todo projeto(nota que é injetado no construtor)
    /// </summary>
    public class TransactionService : ITransactionService
    {
        protected ITransacaoRepository _transacaoRepository;
        public TransactionService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        /// <summary>
        /// Método responsável por consolidar as informções
        /// A princípio a propriedade TipoTransacao possui os dois valores:
        /// 0 - Debito
        /// 1 - Credito
        /// </summary>
        /// <param name="transacao"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<FluxoCaixaConsolidadoDto> GetConsolidadoDiario(string data)
        {
            var dbResult = await _transacaoRepository.GetConsolidadoDiarioAsync(DateTime.Parse(data));
            var TotalCredito = dbResult.Where(t => t.TipoTransacao == 1).Sum(t => t.Valor);
            var TotalDebito = dbResult.Where(t => t.TipoTransacao == 0).Sum(t => t.Valor);

            return new FluxoCaixaConsolidadoDto
            {
                Data = data,
                TotalSaidas = (double?)TotalDebito,
                TotalEntradas = (double?)TotalCredito,
                TotalConsolidado = (double?)(TotalCredito - TotalDebito)
            };
        }

        /// <summary>
        /// Método responsável por toda transação do fluxo de caixa
        /// A princípio a propriedade TipoTransacao possui os dois valores:
        /// 0 - Debito
        /// 1 - Credito
        /// </summary>
        /// <param name="transacao"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<bool> SetTransacaoFluxoCaixa(TransacaoDto transacao)
        {
            if (transacao == null)
                throw new ArgumentNullException("O objeto transacao não pode ser null");

            if (transacao.DataTransacao == null)
                throw new ArgumentNullException("A data do objeto transacao não pode ser null");

            if (transacao.Valor <= 0)
                throw new ArgumentNullException("O Valor do objeto transacao não pode ser menor ou igual a 0");

            if (transacao.TipoTransacao != 0 && transacao.TipoTransacao != 1)
                throw new ArgumentNullException("O TipoTransacao do objeto transacao não pode ser diferente de 0 (Débito) ou 1(Crédito)");

            return await _transacaoRepository.InsertTransacaoAsync(new Transacao
            {
                DataTransacao = DateTime.Parse(transacao.DataTransacao),
                TipoTransacao = transacao.TipoTransacao,
                Valor = transacao.Valor
            });
        }
    }
}
