using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SiControleCaixa.Infrastructure.Data.Models;
using SiControleCaixa.Infrastructure.Data.Mappings;
using Microsoft.Extensions.Configuration;

namespace SiControleCaixa.Infrastructure.Data.Context
{


    public class SiControleCaixaSqlContext : DbContext
    {
        public SiControleCaixaSqlContext()
        {

        }
        public SiControleCaixaSqlContext(DbContextOptions<SiControleCaixaSqlContext> options) : base(options)
        {

        }

        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");
            modelBuilder.Entity<Transacao>();
            modelBuilder.ApplyConfiguration(new TransacaoEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                var connectionString = configuration.GetConnectionString("SiControleCaixaConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
