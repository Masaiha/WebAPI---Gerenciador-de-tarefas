using MasaIO.business.Interface.Repository;
using MasaIO.business.Interface.Services;
using MasaIO.business.Model;
using System;
using System.Threading.Tasks;

namespace MasaIO.business.Service
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        private IBaseRepository<TEntity> Repository
        {
            get;
        }

        protected BaseService(IBaseRepository<TEntity> baseRepository)
        {
            Repository = baseRepository;
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            await Repository.Adicionar(entity);
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            await Repository.Atualizar(entity);
        }

        public virtual async Task Remover(Guid id)
        {
            await Repository.Remover(id);
        }

        public void Dispose()
        {
            Repository?.Dispose();
        }
    }
}
