﻿using AutoMapper;
using MasaIO.API.Constantes;
using MasaIO.API.ViewModels;
using MasaIO.business.Interface.Repository;
using MasaIO.business.Interface.Services;
using MasaIO.business.Interface.Validation;
using MasaIO.business.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasaIO.API.Controllers
{
    [Route("api/tarefas")]
    public class TarefaController : MainController
    {

        private readonly ITarefaRepository _tarefaRepository;
        private readonly ITarefaService _tarefaService;
        private readonly IMapper _mapper;

        public TarefaController(ITarefaRepository tarefaRepository, 
                                IMapper mapper, 
                                ITarefaService tarefaService,
                                INotificador notificador) : base(notificador)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<IEnumerable<TarefaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TarefaViewModel>>(await _tarefaRepository.ObterTarefasEquipes());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TarefaViewModel>> ObterPorId(Guid id)
        {
            var tarefaViewModel = _mapper.Map<TarefaViewModel>(await _tarefaRepository.ObterPorId(id));

            if (tarefaViewModel == null) return NotFound();

            return tarefaViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<TarefaViewModel>> Adicionar(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(tarefaViewModel);

            await _tarefaService.Adicionar(_mapper.Map<Tarefa>(tarefaViewModel));

            return CustomResponse(tarefaViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TarefaViewModel>> Atualizar(Guid id, TarefaViewModel tarefaViewModel)
        {
            if (id != tarefaViewModel.Id)
            {
                NotificarErro(MessagensDeErro.IdDiferenteDoIdObjeto);
                return CustomResponse(tarefaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(tarefaViewModel);

            await _tarefaService.Atualizar(_mapper.Map<Tarefa>(tarefaViewModel));

            return CustomResponse(tarefaViewModel);
        }

        [HttpDelete]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var tarefa = _tarefaRepository.ObterPorId(id);

            if (tarefa == null) return NotFound();

            await _tarefaService.Remover(id);

            return CustomResponse();
        }

    }
}
