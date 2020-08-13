using MasaIO.business.Interface.Repository;
using MasaIO.business.Model;
using MasaIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasaIO.Data.Repository
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(GerenciadorTarefasContext db, DbSet<Tarefa> dbSet) : base(db, dbSet) { }

        public async Task<IEnumerable<Tarefa>> ObterTarefasEquipes()
        {
            return await Db.Tarefas.AsNoTracking().Include(e => e.Equipe).ToListAsync();
        }

    }
}
