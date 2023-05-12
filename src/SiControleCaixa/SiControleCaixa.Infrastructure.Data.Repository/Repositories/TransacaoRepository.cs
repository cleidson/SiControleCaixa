using Microsoft.EntityFrameworkCore;
using SiControleCaixa.Infrastructure.Data.Context;
using SiControleCaixa.Infrastructure.Data.Models;
using SiControleCaixa.Infrastructure.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.Infrastructure.Data.Repository.Repositories
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        protected readonly SiControleCaixaSqlContext _context;
        public TransacaoRepository(SiControleCaixaSqlContext context) : base(context)=> _context = context;
        public async Task<List<Transacao>> GetConsolidadoDiarioAsync(DateTime? data) => await _context.Transacoes.Where(t => t.DataTransacao.Equals(data)).ToListAsync();
        public async Task<bool> InsertTransacaoAsync(Transacao transacao) => await AddAsync(transacao);
    }
}
