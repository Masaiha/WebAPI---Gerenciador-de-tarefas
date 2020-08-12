using MasaIO.business.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasaIO.business.Interface.Repository
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ObterTarefasPorEquipe();

        Task<Tarefa> ObterTarefa();

        Task<Tarefa> ObterTarefasEquipes();
    }
}
