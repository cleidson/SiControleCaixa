using Microsoft.Extensions.DependencyInjection;
using SiControleCaixa.ApplicationCore.BusinessServices.Interfaces;
using SiControleCaixa.ApplicationCore.BusinessServices.Services;
using SiControleCaixa.Infrastructure.Data.Context;
using SiControleCaixa.Infrastructure.Data.Repository.Interfaces;
using SiControleCaixa.Infrastructure.Data.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.Application.NET7.Tests
{
    public static class Startup
    {

        public static IServiceProvider Configure()
        {
            var services = new ServiceCollection();

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<SiControleCaixaSqlContext>();

            return services.BuildServiceProvider();
        }
    }
}
