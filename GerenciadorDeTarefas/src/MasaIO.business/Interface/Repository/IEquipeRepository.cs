using MasaIO.business.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasaIO.business.Interface.Repository
{
    public interface IEquipeRepository : IBaseRepository<Equipe>
    {
        Task<IEnumerable<Equipe>> ObterEquipesTarefas();

    }
}
