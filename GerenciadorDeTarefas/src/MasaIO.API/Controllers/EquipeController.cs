using AutoMapper;
using MasaIO.API.ViewModels;
using MasaIO.business.Interface.Repository;
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
        public async Task<ActionResult<EquipeViewModel>> ObterTodos()
        {
            var equipe = _mapper.Map<EquipeViewModel>(_equipeRepository.)
        }
    }
}
