using MasaIO.business.Interface.Repository;
using MasaIO.business.Interface.Services;
using MasaIO.business.Model;

namespace MasaIO.business.Service
{
    public class EquipeService : BaseService<Equipe>, IEquipeService
    {
        private readonly IEquipeRepository _equipeRepository;
        public EquipeService(IEquipeRepository equipeRepository) : base(equipeRepository)
        {
            _equipeRepository = equipeRepository;
        }
    }
}
