using MasaIO.business.Interface.Repository;
using MasaIO.business.Model;
using MasaIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasaIO.Data.Repository
{
    public class EquipeRepository : BaseRepository<Equipe>, IEquipeRepository
    {
        public EquipeRepository(GerenciadorTarefasContext context) : base(context) { }

        public async Task<IEnumerable<Equipe>> ObterEquipesTarefas()
        {
            var equipesTarefas = await Db.Equipes.AsNoTracking()
                                    .Include(e => e.Tarefas)
                                    .ToArrayAsync();

            return equipesTarefas;
        }
    }
}
