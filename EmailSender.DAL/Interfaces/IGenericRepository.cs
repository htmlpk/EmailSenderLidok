using EmailSender.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Create(TEntity entity);
        Task CreateBatch(IEnumerable<TEntity> entity);
        Task Update(Guid id, TEntity entity);
        void UpdateBatch(IEnumerable<TEntity> entities);
        Task Delete(Guid id);
    }
}
