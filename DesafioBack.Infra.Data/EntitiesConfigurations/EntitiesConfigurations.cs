using DesafioBack.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DesafioBack.Infra.Data.EntitiesConfigurations
{
    public class EntitiesConfigurations : IEntityTypeConfiguration<TaskTool>
    {
        public void Configure(EntityTypeBuilder<TaskTool> builder)
        {
            builder.HasKey(t => t.Id).HasName("id");
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Titulo).HasMaxLength(50).HasColumnName("titulo").IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(200).HasColumnName("descricao").IsRequired();
            builder.Property(p => p.DataCriacao).HasColumnName("data_criacao");
            builder.Property(p => p.DataAtualizacao).HasColumnName("data_atualizacao");

            InjectionData(builder);
        }

        private static void InjectionData(EntityTypeBuilder<TaskTool> builder)
        {
            builder.HasData(
                new TaskTool(1, "Titulo 1", "Teste de Descrição 1", DateTime.Now),
                new TaskTool(2, "Titulo 2", "Teste de Descrição 2", DateTime.Now),
                new TaskTool(3, "Titulo 3", "Teste de Descrição 3", DateTime.Now)
                );
        }
    }
}
