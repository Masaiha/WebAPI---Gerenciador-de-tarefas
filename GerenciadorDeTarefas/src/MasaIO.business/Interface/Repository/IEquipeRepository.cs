using MasaIO.business.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasaIO.business.Interface.Repository
{
    public interface IEquipeRepository
    {
        Task<IEnumerable<Equipe>> ObterEquipesTarefas();

    }
}
