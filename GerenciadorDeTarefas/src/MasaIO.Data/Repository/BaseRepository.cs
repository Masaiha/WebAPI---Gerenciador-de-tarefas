using MasaIO.business.Interface.Repository;
using MasaIO.business.Model;
using MasaIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MasaIO.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly GerenciadorTarefasContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(GerenciadorTarefasContext db, DbSet<TEntity> dbSet)
        {
            Db = db;
            DbSet = dbSet;
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
