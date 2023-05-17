using Microsoft.AspNetCore.Mvc;
using SiControleCaixa.ApplicationCore.BusinessServices.Interfaces;
using SiControleCaixa.ApplicationCore.DTO.Transacao;

namespace SiControleCaixa.Application.NET7.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet("consolidado/diario/{data}")]
        public async Task<ActionResult> GetConsolidadoDiario(string data) => Ok(await _transactionService.GetConsolidadoDiario(data));


        [HttpPost("lancamento")]
        public async Task<ActionResult> Post([FromBody] TransacaoDto lancamento) => Ok( await _transactionService.SetTransacaoFluxoCaixa(lancamento));
    }
}
