using MasaIO.business.Model;
using System;
using System.Threading.Tasks;

namespace MasaIO.business.Interface.Services
{
    public interface IBaseService<TEntity>: IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);

        Task Atualizar(TEntity entity);

        Task Remover(Guid id);
    }
}
