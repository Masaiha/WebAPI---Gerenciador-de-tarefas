using MasaIO.business.Interface.Repository;
using MasaIO.business.Interface.Services;
using MasaIO.business.Model;

namespace MasaIO.business.Service
{
    public class TarefaService : BaseService<Tarefa>, ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository) : base(tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
    }
}
