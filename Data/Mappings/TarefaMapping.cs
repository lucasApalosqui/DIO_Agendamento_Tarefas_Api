using DioAgendamentoTarefasApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DioAgendamentoTarefasApi.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tbl_Tarefa");

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Date)
                .HasColumnName("Data")
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .IsRequired();
        }
    }
}
