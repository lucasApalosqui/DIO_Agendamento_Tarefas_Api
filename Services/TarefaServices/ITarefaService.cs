using DioAgendamentoTarefasApi.Data;
using DioAgendamentoTarefasApi.Enums;
using DioAgendamentoTarefasApi.ViewModels.TarefaViewModels;

namespace DioAgendamentoTarefasApi.Services.TarefaServices
{
    public interface ITarefaService
    {
        public Task<GetTarefasViewModel> CreateTarefa(DataContext context, CreateTarefaViewModel model);
        public Task<GetTarefasViewModel> UpdateTarefaInfo(DataContext context, UpdateTarefaInfoViewModel model, Guid id);
        public Task<GetTarefasViewModel> MoveTarefaToTrash(DataContext context, Guid id);
        public Task<GetTarefasViewModel> GetTarefaById(DataContext context, Guid id);
        public Task<List<GetTarefasViewModel>> GetAllTarefas(DataContext context);
        public Task<List<GetTarefasViewModel>> GetTarefasByTitulo(DataContext context, string titulo);
        public Task<List<GetTarefasViewModel>> GetTarefasByData(DataContext context, GetTarefasByDataViewModel model);
        public Task<List<GetTarefasViewModel>> GetTarefasByStatus(DataContext context, Status status);
        public Task<GetTarefasViewModel> AddDaysInTarefa(DataContext context, Guid id, int days);
        public Task<Guid> RemoveTarefaById(DataContext context, Guid guid);
    }
}
