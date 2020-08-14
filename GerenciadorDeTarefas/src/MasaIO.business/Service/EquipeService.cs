using MasaIO.business.Interface.Repository;
using MasaIO.business.Interface.Services;
using MasaIO.business.Interface.Validation;
using MasaIO.business.Model;
using MasaIO.business.Validations;

namespace MasaIO.business.Service
{
    public class EquipeService : BaseService<Equipe>, IEquipeService
    {
        private readonly IEquipeRepository _equipeRepository;
        public EquipeService(IEquipeRepository equipeRepository,
                             INotificador notificador) : base(equipeRepository, new EquipeValidation(), notificador)
        {
            _equipeRepository = equipeRepository;
        }
    }
}
