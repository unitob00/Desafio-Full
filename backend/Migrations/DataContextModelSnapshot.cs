﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TituloEmAtraso.Data;

namespace TituloEmAtraso.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TituloEmAtraso.Models.Parcela", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdTituloAtraso")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumeroParcela")
                        .HasColumnType("int");

                    b.Property<Guid?>("TituloAtrasoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorParcela")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("TituloAtrasoId");

                    b.ToTable("Parcela");
                });

            modelBuilder.Entity("TituloEmAtraso.Models.TituloAtraso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<decimal>("Juros")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Multa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumeroTitulo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TituloAtraso");
                });

            modelBuilder.Entity("TituloEmAtraso.Models.Parcela", b =>
                {
                    b.HasOne("TituloEmAtraso.Models.TituloAtraso", "TituloAtraso")
                        .WithMany("Parcelas")
                        .HasForeignKey("TituloAtrasoId");

                    b.Navigation("TituloAtraso");
                });

            modelBuilder.Entity("TituloEmAtraso.Models.TituloAtraso", b =>
                {
                    b.Navigation("Parcelas");
                });
#pragma warning restore 612, 618
        }
    }
}
