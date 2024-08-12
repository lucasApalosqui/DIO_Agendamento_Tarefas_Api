using DioAgendamentoTarefasApi.Enums;

namespace DioAgendamentoTarefasApi.ViewModels.TarefaViewModels
{
    public class GetTarefasViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
    }
}
