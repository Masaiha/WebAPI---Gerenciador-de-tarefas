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
        public EquipeRepository(GerenciadorTarefasContext db, DbSet<Equipe> dbSet) : base(db, dbSet) { }

        public async Task<IEnumerable<Equipe>> ObterEquipesTarefas()
        {
            return await DbSet.AsNoTracking().Include(e => e.Tarefas).ToListAsync();
        }
    }
}
