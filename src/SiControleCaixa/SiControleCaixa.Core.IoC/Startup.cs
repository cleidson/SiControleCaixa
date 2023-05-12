using Microsoft.Extensions.DependencyInjection;
using SiControleCaixa.ApplicationCore.BusinessServices.Interfaces;
using SiControleCaixa.ApplicationCore.BusinessServices.Services;
using SiControleCaixa.Infrastructure.Data.Repository.Interfaces;
using SiControleCaixa.Infrastructure.Data.Repository.Repositories;
using System.ComponentModel;

namespace SiControleCaixa.ApplicationCore.IoC
{
    public static class Startup
    {
        public static void RegisterServices(this IServiceCollection services)
		{
			try
			{ 
                services.AddScoped<ITransactionService, TransactionService>();
                services.AddScoped<ITransacaoRepository, TransacaoRepository>();
                

            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}