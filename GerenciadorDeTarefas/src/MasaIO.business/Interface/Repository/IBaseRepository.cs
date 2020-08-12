using MasaIO.business.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MasaIO.business.Interface.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);

        Task<TEntity> ObterPorId(Guid id);

        Task<IEnumerable<TEntity>> ObterTodos();

        Task Atualizar(TEntity entity);

        Task Remover(Guid id);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();

    }
}
