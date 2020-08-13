using AutoMapper;
using MasaIO.API.ViewModels;
using MasaIO.business.Interface.Repository;
using MasaIO.business.Model;
using MasaIO.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasaIO.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            CreateMap<Equipe, EquipeViewModel>().ReverseMap();
            CreateMap<Tarefa, TarefaViewModel>().ReverseMap();

            
        }
    }
}
