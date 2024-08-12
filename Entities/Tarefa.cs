using DioAgendamentoTarefasApi.Enums;

namespace DioAgendamentoTarefasApi.Entities
{
    public class Tarefa
    {
        public Tarefa(string titulo, string descricao, DateTime date)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            Date = date;
            Status = Status.Pendente;
        }
        public Guid Id { get; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Date { get; private set; }
        public Status Status { get; private set; }

        public void AlterarInformacoes(string? titulo, string? descricao)
        {
            if (!string.IsNullOrEmpty(descricao))
                Descricao = descricao;

            if (!string.IsNullOrEmpty(titulo))
                Titulo = titulo;
        }

        public void AumentarDias(int dias)
        {
            if(dias > 0)
                Date = Date.AddDays(dias);
        }

        public void EnviarParaLixeira()
        {
            Status = Status.Cancelado;
        }

        public void ConcluirTarefa()
        {
            Status = Status.Concluido;
        }
    }
}
