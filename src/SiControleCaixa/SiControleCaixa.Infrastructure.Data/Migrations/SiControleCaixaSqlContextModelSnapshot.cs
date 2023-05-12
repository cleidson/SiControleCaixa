﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiControleCaixa.Infrastructure.Data.Context;

#nullable disable

namespace SiControleCaixa.Infrastructure.Data.Migrations
{
    [DbContext(typeof(SiControleCaixaSqlContext))]
    partial class SiControleCaixaSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Latin1_General_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SiControleCaixa.Infrastructure.Data.Models.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataTransacao")
                        .HasColumnType("datetime");

                    b.Property<int>("TipoTransacao")
                        .HasColumnType("int")
                        .HasColumnName("TipoTransacao");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id")
                        .HasName("Id");

                    b.ToTable("Transacao", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
