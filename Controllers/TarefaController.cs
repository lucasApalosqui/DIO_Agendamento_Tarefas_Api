using DioAgendamentoTarefasApi.Data;
using DioAgendamentoTarefasApi.Enums;
using DioAgendamentoTarefasApi.Services.TarefaServices;
using DioAgendamentoTarefasApi.ViewModels;
using DioAgendamentoTarefasApi.ViewModels.TarefaViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DioAgendamentoTarefasApi.Controllers
{
    [ApiController]
    public class TarefaController : ControllerBase
    {
        [Route("v1/tarefa/")]
        [HttpPost]
        public async Task<IActionResult> CreateTarefa([FromServices] DataContext context, [FromBody] CreateTarefaViewModel model)
        {
            try
            {
                TarefaService service = new TarefaService();
                var tarefaCreateResponse = await service.CreateTarefa(context, model);

                if(tarefaCreateResponse == null)
                    return NotFound(new ResultViewModel<GetTarefasViewModel>("8KYP50 - Nenhuma tarefa encontrada"));

                return Ok(new ResultViewModel<GetTarefasViewModel>(tarefaCreateResponse));


            }catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("v1/tarefa/{id}/alterarInfo")]
        [HttpPut]
        public async Task<IActionResult> UpdateInfo([FromServices] DataContext context, [FromBody] UpdateTarefaInfoViewModel model, [FromRoute] string id)
        {
            try
            {
                var guidId = new Guid(id);
                var service = new TarefaService();
                var response = await service.UpdateTarefaInfo(context, model, guidId);

                if (response == null)
                    return NotFound(new ResultViewModel<GetTarefasViewModel>("5LMPL0 - Tarefa não encontrada"));


                return Ok(new ResultViewModel<GetTarefasViewModel>(response));

            }catch(Exception ex)
            {
                return StatusCode(500);
            }
            
        }

        [Route("v1/tarefa/{id}/moverParaLixeira")]
        [HttpPut]
        public async Task<IActionResult> MoveTarefaToTrash([FromServices] DataContext context, [FromRoute] string id)
        {
            try
            {
                var service = new TarefaService();
                var guidId = new Guid(id);
                var response = await service.MoveTarefaToTrash(context, guidId);

                if (response == null)
                    return NotFound(new ResultViewModel<GetTarefasViewModel>("9LKBV0 - Tarefa não encontrada"));

                return Ok(new ResultViewModel<GetTarefasViewModel>(response));


            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("v1/tarefa/{id}/adiarData/{dias}")]
        [HttpPut]
        public async Task<IActionResult> AddDaysInData([FromServices]DataContext context, string id, int dias)
        {
            try
            {
                var service = new TarefaService();
                var guidId = new Guid(id);
                var response = await service.AddDaysInTarefa(context, guidId, dias);

                if (response == null)
                    return NotFound(new ResultViewModel<GetTarefasViewModel>("451LAS - Tarefa não encontrada"));

                return Ok(new ResultViewModel<GetTarefasViewModel>(response));

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("v1/tarefa/{id}/remover")]
        [HttpDelete]
        public async Task<IActionResult> RemoveTarefa([FromServices] DataContext context, string id)
        {
            try
            {
                var service = new TarefaService();
                var guidId = new Guid(id);
                var response = await service.RemoveTarefaById(context, guidId);
                if(response == null)
                    return NotFound(new ResultViewModel<GetTarefasViewModel>("HGBNM8 - Tarefa não encontrada"));

                return Ok(new ResultViewModel<Guid>(response));


            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("v1/tarefa/obterPeloId/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTarefaById([FromServices] DataContext context, string id)
        {
            try
            {
                var service = new TarefaService();
                var guidId = new Guid(id);
                var response = await service.GetTarefaById(context, guidId);

                if (response == null)
                    return NotFound(new ResultViewModel<GetTarefasViewModel>("NBHGV4 - Nenhuma Tarefa encontrada"));

                return Ok(new ResultViewModel<GetTarefasViewModel>(response));

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("v1/tarefa/")]
        [HttpGet]
        public async Task<IActionResult> GetAllTarefas([FromServices] DataContext context)
        {
            try
            {
                var service = new TarefaService();
                var response = await service.GetAllTarefas(context);

                if (response == null)
                    return NotFound(new ResultViewModel<GetTarefasViewModel>("NBHGV4 - Nenhuma Tarefa encontrada"));

                return Ok(new ResultViewModel<List<GetTarefasViewModel>>(response));

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("v1/tarefa/obterPorTitulo/{titulo}")]
        [HttpGet]
        public async Task<IActionResult> GetByTitulo([FromServices] DataContext context, string titulo)
        {
            try
            {
                var service = new TarefaService();
                var response = await service.GetTarefasByTitulo(context, titulo);

                if (response == null)
                    return NotFound(new ResultViewModel<GetTarefasViewModel>("5T4RD3 - Nenhuma Tarefa encontrada"));

                return Ok(new ResultViewModel<List<GetTarefasViewModel>>(response));

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("v1/tarefa/obterPorData")]
        [HttpPost]
        public async Task<IActionResult> GetByData([FromServices] DataContext context,[FromBody]GetTarefasByDataViewModel model)
        {
            try
            {
                var service = new TarefaService();
                var response = await service.GetTarefasByData(context, model);

                if (response == null)
                    return NotFound(new ResultViewModel<GetTarefasViewModel>("LKMNBH - Nenhuma Tarefa encontrada"));

                return Ok(new ResultViewModel<List<GetTarefasViewModel>>(response));

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("v1/tarefa/obterPorStatus/{status}")]
        [HttpGet]
        public async Task<IActionResult> GetByStatus([FromServices] DataContext context, string status)
        {
            try
            {
                var service = new TarefaService();
                try
                {
                    Status statusVeri = (Status)Enum.Parse(typeof(Status), status);
                    var response = await service.GetTarefasByStatus(context, statusVeri);

                    if (response == null)
                        return NotFound(new ResultViewModel<GetTarefasViewModel>("LKMNBH - Nenhuma Tarefa encontrada"));

                    return Ok(new ResultViewModel<List<GetTarefasViewModel>>(response));
                }
                catch
                {
                    return NotFound(new ResultViewModel<GetTarefasViewModel>("LKMNBH - Status inválido"));
                }

              
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
