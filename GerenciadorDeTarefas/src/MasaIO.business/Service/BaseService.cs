using FluentValidation;
using MasaIO.business.Interface.Repository;
using MasaIO.business.Interface.Services;
using MasaIO.business.Interface.Validation;
using MasaIO.business.Model;
using MasaIO.business.Service.Validation;
using System;
using System.Threading.Tasks;

namespace MasaIO.business.Service
{
    public abstract class BaseService<TEntity> : BaseServiceValidation,  IBaseService<TEntity> where TEntity : Entity
    {
        private IBaseRepository<TEntity> Repository { get; }
        protected AbstractValidator<TEntity> AbstractValidator { get; }

        protected BaseService(IBaseRepository<TEntity> baseRepository, 
                              AbstractValidator<TEntity> abstractValidator,
                              INotificador notificador) : base(notificador)
        {
            Repository = baseRepository;
            AbstractValidator = abstractValidator;
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            if (!ExecutarValidacao(AbstractValidator, entity)) return;

            await Repository.Adicionar(entity);
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            if (!ExecutarValidacao(AbstractValidator, entity)) return;

            await Repository.Atualizar(entity);
        }

        public virtual async Task Remover(Guid id)
        {
            var _entity = Repository.ObterPorId(id);

            if (_entity == null)
            {
                Notificar("O Objeto a ser excluído não existe");
                return;
            }

            await Repository.Remover(id);
        }

        public void Dispose()
        {
            Repository?.Dispose();
        }

    }
}
