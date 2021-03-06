﻿using AutoMapper;
using MasaIO.API.Constantes;
using MasaIO.API.ViewModels;
using MasaIO.business.Interface.Repository;
using MasaIO.business.Interface.Services;
using MasaIO.business.Interface.Validation;
using MasaIO.business.Model;
using MasaIO.business.Validations.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasaIO.API.Controllers
{
    [Route("api/equipes")]
    public class EquipeController : MainController
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly IEquipeService _equipeService;
        private readonly IMapper _mapper;

        public EquipeController(IEquipeRepository equipeRepository, 
                                IMapper mapper, 
                                IEquipeService equipeService,
                                INotificador notificador) : base(notificador)
        {
            _equipeRepository = equipeRepository;
            _mapper = mapper;
            _equipeService = equipeService;
        }

        [HttpGet]
        public async Task<IEnumerable<EquipeViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EquipeViewModel>>(await _equipeRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EquipeViewModel>> ObterPorId(Guid id)
        {
            var equipeViewModel = _mapper.Map<EquipeViewModel>(await _equipeRepository.ObterPorId(id));

            if (equipeViewModel == null) return NotFound();

            return Ok(equipeViewModel);
        }

        [HttpGet("obter-equipes-tarefas")]
        public async Task<IEnumerable<EquipeViewModel>> ObterEquipesTarefas()
        {
            return _mapper.Map<IEnumerable<EquipeViewModel>>(await _equipeRepository.ObterEquipesTarefas());
        }

        [HttpPost]
        public async Task<ActionResult<EquipeViewModel>> Adicionar(EquipeViewModel equipeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(equipeViewModel);

            await _equipeService.Adicionar(_mapper.Map<Equipe>(equipeViewModel));

            return CustomResponse(equipeViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EquipeViewModel>> Atualizar(Guid id, EquipeViewModel equipeViewModel)
        {
            if (id != equipeViewModel.Id)
            {
                NotificarErro(MessagensDeErro.IdDiferenteDoIdObjeto);
                return CustomResponse(equipeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(equipeViewModel);

            var equipe = _mapper.Map<Equipe>(equipeViewModel);

            await _equipeService.Atualizar(equipe);

            return CustomResponse(equipeViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var equipe = await _equipeRepository.ObterPorId(id);

            if (equipe == null) return NotFound();

            await _equipeService.Remover(id);

            return CustomResponse();
        }
    }
}
