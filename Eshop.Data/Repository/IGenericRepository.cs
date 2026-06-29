using Eshop.Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Data.Repository
{
    public interface IGenericRepository<TEntity> 
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetEntitiesQuery();

        TEntity GetEntityById(long entityId);

        void AddEntity(TEntity entity);

        void UpdateEntity(TEntity entity);

        void RemoveEntity(TEntity entity);

        void RemoveEntity(long entityId);

        void SaveChanges();
    }
}
