using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntitiesConfiguration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(prop => prop.IdPedido);

            builder.Property(prop => prop.IdPedido)
                   .IsRequired()
                   .HasColumnName("IdPedido")
                   .HasColumnType("int");

            builder.Property(prop => prop.NumeroPedido)
                .IsRequired()
                .HasColumnName("NumeroPedido")
                   .HasColumnType("int");

            builder.Property(prop => prop.HoraPedido)
                .IsRequired()
                .HasColumnName("HoraPedido")
                   .HasColumnType("DateTime");

            builder.Property(prop => prop.EhCancelado)
                .HasColumnName("IndCancelado");

            builder.Property(prop => prop.EhConcluido)
                .HasColumnName("IndConcluido");


        }
    }
}
