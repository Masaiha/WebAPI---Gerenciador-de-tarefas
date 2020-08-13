using AutoMapper;
using MasaIO.API.ViewModels;
using MasaIO.business.Model;

namespace MasaIO.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            CreateMap<Equipe, EquipeViewModel>().ReverseMap();

            CreateMap<Tarefa, TarefaViewModel>()
                .ForMember(dest => dest.EquipeNome, opt => opt.MapFrom(src => src.Equipe.Nome));


            CreateMap<TarefaViewModel, Tarefa>();

        }
    }
}
