using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntitiesConfiguration
{
    public class TipoOcorrenciaConfiguration : IEntityTypeConfiguration<TipoOcorrencia>
    {
        public void Configure(EntityTypeBuilder<TipoOcorrencia> builder)
        {
            builder.ToTable("TipoOcorrencia");

            builder.HasKey(prop => prop.IdTipoOcorrencia);

            builder.Property(prop => prop.IdTipoOcorrencia)
                   .IsRequired()
                   .HasColumnName("IdTipoOcorrencia")
                   .HasColumnType("int");

            builder.Property(prop => prop.Descricao)
                   .IsRequired()
                   .HasColumnName("Descricao")
                   .HasMaxLength(100);
        }
    }
}
