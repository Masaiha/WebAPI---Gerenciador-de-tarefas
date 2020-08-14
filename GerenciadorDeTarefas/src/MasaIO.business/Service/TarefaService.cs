using FluentValidation;
using MasaIO.business.Interface.Repository;
using MasaIO.business.Interface.Services;
using MasaIO.business.Interface.Validation;
using MasaIO.business.Model;
using MasaIO.business.Validations;
using System;
using System.Threading.Tasks;

namespace MasaIO.business.Service
{
    public class TarefaService : BaseService<Tarefa>, ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository,
                             INotificador notificador)
            : base(tarefaRepository, new TarefaValidation(), notificador)
        {
            _tarefaRepository = tarefaRepository;
        }

        public override async Task Atualizar(Tarefa tarefa)
        {
            if (!ExecutarValidacao(AbstractValidator, tarefa)) return;

            var tarefaAtualizacao = await _tarefaRepository.ObterPorId(tarefa.Id);

            tarefaAtualizacao.Titulo = tarefa.Titulo;
            tarefaAtualizacao.Descricao = tarefa.Descricao;
            tarefaAtualizacao.EquipeId = tarefa.EquipeId;
            tarefaAtualizacao.Estado = tarefa.Estado;
            tarefaAtualizacao.DataUltimaAlteracao = DateTime.UtcNow.Date;

            await _tarefaRepository.Atualizar(tarefaAtualizacao);
        }
    }
}
