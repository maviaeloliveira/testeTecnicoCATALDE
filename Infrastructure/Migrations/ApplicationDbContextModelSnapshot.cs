﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Ocorrencia", b =>
                {
                    b.Property<int>("IdOcorrencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdOcorrencia");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOcorrencia"), 1L, 1);

                    b.Property<bool>("EhFinalizadora")
                        .HasColumnType("bit")
                        .HasColumnName("ehFinalizadora");

                    b.Property<DateTime>("HoraOcorrencia")
                        .HasColumnType("DateTime")
                        .HasColumnName("HoraOcorrencia");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int")
                        .HasColumnName("IdPedido");

                    b.Property<int>("IdTipoOcorrencia")
                        .HasColumnType("int")
                        .HasColumnName("IdTipoOcorrencia");

                    b.HasKey("IdOcorrencia");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdTipoOcorrencia");

                    b.ToTable("Ocorrencia", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdPedido");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"), 1L, 1);

                    b.Property<bool>("EhCancelado")
                        .HasColumnType("bit")
                        .HasColumnName("IndCancelado");

                    b.Property<bool>("EhConcluido")
                        .HasColumnType("bit")
                        .HasColumnName("IndConcluido");

                    b.Property<DateTime>("HoraPedido")
                        .HasColumnType("DateTime")
                        .HasColumnName("HoraPedido");

                    b.Property<int>("NumeroPedido")
                        .HasColumnType("int")
                        .HasColumnName("NumeroPedido");

                    b.HasKey("IdPedido");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipoOcorrencia", b =>
                {
                    b.Property<int>("IdTipoOcorrencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdTipoOcorrencia");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoOcorrencia"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Descricao");

                    b.HasKey("IdTipoOcorrencia");

                    b.ToTable("TipoOcorrencia", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Ocorrencia", b =>
                {
                    b.HasOne("Domain.Entities.Pedido", "Pedido")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoOcorrencia", "TipoOcorrencia")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("IdTipoOcorrencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("TipoOcorrencia");
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.Navigation("Ocorrencias");
                });

            modelBuilder.Entity("Domain.Entities.TipoOcorrencia", b =>
                {
                    b.Navigation("Ocorrencias");
                });
#pragma warning restore 612, 618
        }
    }
}
