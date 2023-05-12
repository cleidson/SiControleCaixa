using Microsoft.Extensions.DependencyInjection;
using SiControleCaixa.ApplicationCore.BusinessServices.Interfaces;
using SiControleCaixa.ApplicationCore.BusinessServices.Services;
using SiControleCaixa.ApplicationCore.DTO.Transacao;
using SiControleCaixa.Infrastructure.Data.Models;

namespace SiControleCaixa.Application.NET7.Tests
{
    [TestClass]
    public class UnitTestFluxoCaixa
    {
        private IServiceProvider _serviceProvider;

        [TestInitialize]
        public void Initialize()
        {
            _serviceProvider = Startup.Configure();
        }


        [TestMethod]
        public async Task SetTransacaoFluxoCaixa()
        {
            var transactionServiceDependency = _serviceProvider.GetService<ITransactionService>();

            var cenario01 = new TransacaoDto
            {
                DataTransacao = "2023-10-12",
                TipoTransacao = 5,
                Valor = 5
            };

            var cenario02 = new TransacaoDto
            {
                DataTransacao = "2023-10-12",
                TipoTransacao = 1,
                Valor = 0
            };

            Assert.IsTrue(cenario02.Valor == 0);


            var cenario03 = new TransacaoDto
            {
                DataTransacao = null,
                TipoTransacao = 1,
                Valor = 5
            };

            Assert.IsTrue(cenario03.DataTransacao  is null);

            var result = await transactionServiceDependency.SetTransacaoFluxoCaixa(cenario01);

            Assert.IsNotNull(result);
        }




        [TestMethod]
        public async Task GetConsolidadoDiario()
        {
            var transactionServiceDependency = _serviceProvider.GetService<ITransactionService>();

            var result = await transactionServiceDependency.GetConsolidadoDiario("2023-10-12");

            Assert.IsNotNull(result);
        }
    }
}