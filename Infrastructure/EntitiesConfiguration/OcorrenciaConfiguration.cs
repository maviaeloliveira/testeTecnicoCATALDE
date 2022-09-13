using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.EntitiesConfiguration
{
    public class OcorrenciaConfiguration : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.ToTable("Ocorrencia");

            builder.HasKey(prop => prop.IdOcorrencia);

            builder.Property(prop => prop.IdOcorrencia)
                   .IsRequired()
                   .HasColumnName("IdOcorrencia")
                   .HasColumnType("int");

            builder.Property(prop => prop.IdPedido)
                .IsRequired()
                .HasColumnName("IdPedido")
                .HasColumnType("int");

            builder.HasOne(prop => prop.Pedido)
                     .WithMany(a => a.Ocorrencias)
                     .HasForeignKey(prop => prop.IdPedido);

            builder.Property(prop => prop.IdTipoOcorrencia)
                .IsRequired()
                .HasColumnName("IdTipoOcorrencia")
                .HasColumnType("int");

            builder.HasOne(prop => prop.TipoOcorrencia)
                     .WithMany(a => a.Ocorrencias)
                     .HasForeignKey(prop => prop.IdTipoOcorrencia);

            builder.Property(prop => prop.HoraOcorrencia)
                .IsRequired()
                .HasColumnName("HoraOcorrencia")
                   .HasColumnType("DateTime");

            builder.Property(prop => prop.EhFinalizadora)
                .IsRequired()
                .HasColumnName("ehFinalizadora");

        }
    }
}
