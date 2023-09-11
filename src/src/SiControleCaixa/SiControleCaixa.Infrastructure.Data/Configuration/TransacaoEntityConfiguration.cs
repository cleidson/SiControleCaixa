using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiControleCaixa.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SiControleCaixa.Infrastructure.Data.Mappings
{
    public class TransacaoEntityTypeConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> modelBuilder)
        {
            modelBuilder.ToTable("Transacao");
            modelBuilder.HasKey(t => t.Id).HasName("Id");
            modelBuilder.Property(e => e.Id).HasColumnName("Id").HasColumnType("int").ValueGeneratedOnAdd();
            modelBuilder.Property(e => e.TipoTransacao).HasColumnName("TipoTransacao").HasColumnType("int");
            modelBuilder.Property(e => e.Valor).HasColumnType("float");
            modelBuilder.Property(e => e.DataTransacao).HasColumnType("datetime");
        }
    }
}
