using DioAgendamentoTarefasApi.Data;
using DioAgendamentoTarefasApi.Entities;
using DioAgendamentoTarefasApi.Enums;
using DioAgendamentoTarefasApi.ViewModels.TarefaViewModels;
using Microsoft.EntityFrameworkCore;

namespace DioAgendamentoTarefasApi.Services.TarefaServices
{
    public class TarefaService : ITarefaService
    {
        public async Task<GetTarefasViewModel> AddDaysInTarefa(DataContext context, Guid id, int days)
        {
            var tarefa = await context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            if (tarefa == null)
                return null;

            tarefa.AumentarDias(days);
            context.Tarefas.Update(tarefa);
            await context.SaveChangesAsync();

            return new GetTarefasViewModel
            {
                Id = tarefa.Id,
                Date = tarefa.Date,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status
            };
        }

        public async Task<GetTarefasViewModel> CreateTarefa(DataContext context, CreateTarefaViewModel model)
        {
            var tarefa = new Tarefa(model.Titulo, model.Descricao, model.Data);
            await context.Tarefas.AddAsync(tarefa);
            await context.SaveChangesAsync();

            return new GetTarefasViewModel
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Date = tarefa.Date,
                Status = tarefa.Status
            };
            
        }

        public async Task<List<GetTarefasViewModel>> GetAllTarefas(DataContext context)
        {
            var allTarefas = await context.Tarefas.ToListAsync();

            if (allTarefas.Count == 0)
                return null;

            return GenerateListOfTarefas(allTarefas);
        }

        public async Task<GetTarefasViewModel> GetTarefaById(DataContext context, Guid id)
        {
            var tarefa = await context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            if (tarefa == null)
                return null;

            return new GetTarefasViewModel
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Date = tarefa.Date,
                Status = tarefa.Status
            };
        }

        public async Task<List<GetTarefasViewModel>> GetTarefasByData(DataContext context, DateTime date)
        {
            var tarefas = await context.Tarefas.Where(x => x.Date == date).ToListAsync();
            if (tarefas.Count == 0)
                return null;

            return GenerateListOfTarefas(tarefas);
        }

        public async Task<List<GetTarefasViewModel>> GetTarefasByStatus(DataContext context, Status status)
        {
            var tarefas = await context.Tarefas.Where(x => x.Status == status).ToListAsync();
            if (tarefas.Count == 0)
                return null;

            return GenerateListOfTarefas(tarefas);
        }

        public async Task<List<GetTarefasViewModel>> GetTarefasByTitulo(DataContext context, string titulo)
        {
            var tarefas = await context.Tarefas.Where(x => x.Titulo == titulo).ToListAsync();
            if (tarefas.Count == 0)
                return null;

            return GenerateListOfTarefas(tarefas);
        }

        public async Task<GetTarefasViewModel> MoveTarefaToTrash(DataContext context, Guid id)
        {
            var tarefa = await context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            if (tarefa == null)
                return null;

            tarefa.EnviarParaLixeira();
            context.Tarefas.Update(tarefa);
            await context.SaveChangesAsync();

            return new GetTarefasViewModel
            {
                Id = id,
                Descricao = tarefa.Descricao,
                Date = tarefa.Date,
                Status = tarefa.Status,
                Titulo = tarefa.Titulo
            };
        }

        public async Task<Guid> RemoveTarefaById(DataContext context, Guid guid)
        {
            var tarefa = await context.Tarefas.FirstOrDefaultAsync(x => x.Id == guid);
            if (tarefa == null)
                return Guid.Empty;

            context.Tarefas.Remove(tarefa);
            await context.SaveChangesAsync();

            return guid;
        }

        public async Task<GetTarefasViewModel> UpdateTarefaInfo(DataContext context, UpdateTarefaInfoViewModel model, Guid id)
        {
            var tarefa = await context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
            if (tarefa == null)
                return null;

            tarefa.AlterarInformacoes(model.Titulo, model.Descricao);
            context.Tarefas.Update(tarefa);
            await context.SaveChangesAsync();

            return new GetTarefasViewModel
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Date = tarefa.Date,
                Status = tarefa.Status
            };
        }

        private List<GetTarefasViewModel> GenerateListOfTarefas(List<Tarefa> tarefas)
        {
            List<GetTarefasViewModel> tarefaList = new List<GetTarefasViewModel>();

            foreach (var tarefa in tarefas)
            {
                GetTarefasViewModel tarefaView = new GetTarefasViewModel
                {
                    Id = tarefa.Id,
                    Titulo = tarefa.Titulo,
                    Descricao = tarefa.Descricao,
                    Date = tarefa.Date,
                    Status = tarefa.Status
                };

                tarefaList.Add(tarefaView);

            }
            return tarefaList;
        }
    }
}
