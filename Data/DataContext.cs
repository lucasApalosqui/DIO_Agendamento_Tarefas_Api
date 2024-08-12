using DioAgendamentoTarefasApi.Data.Mappings;
using DioAgendamentoTarefasApi.Entities;
using Microsoft.EntityFrameworkCore;
namespace DioAgendamentoTarefasApi.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMapping());
        }
    }
}
