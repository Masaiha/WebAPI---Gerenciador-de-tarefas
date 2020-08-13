using AutoMapper;
using MasaIO.API.ViewModels;
using MasaIO.business.Interface.Repository;
using MasaIO.business.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasaIO.API.Controllers
{
    [Route("api/equipes")]
    public class EquipeController : MainController
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly IMapper _mapper;

        public EquipeController(IEquipeRepository equipeRepository, IMapper mapper)
        {
            _equipeRepository = equipeRepository;
            _mapper = mapper;
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
            if (!ModelState.IsValid) return BadRequest(equipeViewModel);

            await _equipeRepository.Adicionar(_mapper.Map<Equipe>(equipeViewModel));

            return Ok(equipeViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EquipeViewModel>> Atualizar(Guid id, EquipeViewModel equipeViewModel)
        {
            if (id != equipeViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var equipe = _mapper.Map<Equipe>(equipeViewModel);

            await _equipeRepository.Atualizar(equipe);

            return Ok(equipeViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var equipe = await _equipeRepository.ObterPorId(id);

            if (equipe == null) return NotFound();

            await _equipeRepository.Remover(id);

            return Ok();
        }
    }
}
