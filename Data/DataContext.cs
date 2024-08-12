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
    }
}
