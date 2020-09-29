using Nativa.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Navita.Core.Interfaces
{
    /// <summary>
    /// Interface Base que contêm todos as operações de CRUD
    /// </summary>
    /// <typeparam name="TEntity">Tipo que implementará a interface, deve herdar da classe Base</typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : Base
    {
        Task Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(int id);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<bool> IsAny<T>(IEnumerable<T> data);
    }
}
